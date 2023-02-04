using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ServiceLocator))]
public class ServiceLocatorEditor : BaseEditor<ServiceLocator>
{
    Component[] components;

    void OnEnable()
    {
        SyncServices();
    }

    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("Remove Empty Services"))
        {
            Target.RemoveEmptyServices();
        }

        base.OnInspectorGUI();

        if(AreServicesChanged())
        {
            SyncServices();
            Debug.Log("Services are changed.");
            UpdateServices();
        }
    }

    void SyncServices()
    {
        var services = Target.GetServices();
        components = new Component[services.Length];

        for(int i = 0; i < components.Length; ++i)
        {
            components[i] = services[i];
        }
    }

    bool AreServicesChanged()
    {
        var services = Target.GetServices();

        if (services != null)
        {
            if (services.Length != components.Length)
            {
                return true;
            }

            for (int i = 0; i < components.Length; ++i)
            {
                if (components[i] != services[i])
                {
                    return true;
                }
            }
        }

        return false;
    }

    void UpdateServices()
    {
        Target.FindAndUpdateSingletones();
        EditorUtility.SetDirty(Target);
    }
}
