using System;
using UnityEngine;
#if UNITY_EDITOR
using System.Linq;
#endif

//DEFINE Type for Idintification
using Service = UnityEngine.Component;

[CreateAssetMenu(fileName = FILE_NAME, menuName = "ScriptableObjects/" + FILE_NAME)]
public class ServiceLocator : ScriptableObject
{
    const string FILE_NAME = "ServiceLocator";
    const string INVALID_REQUEST = "ServiceLocator: Invalid Type Request.";

    static ServiceLocator instance;
    static ServiceLocator Instance
    {
        get
        {
            if(instance == null)
            {
                instance = Resources.Load<ServiceLocator>(FILE_NAME);
            }
            return instance;
        }
    }

    [SerializeField] 
    Service[] services = null;

    [SerializeField] 
    ScriptableObject[] scriptableObjects = new ScriptableObject[0];

    class ServiceNotFoundException<T> : Exception
    {
        public override string ToString()
        {
            return $"{INVALID_REQUEST} ({typeof(T).Name})";
        }
    }


    //------------------------------

    internal static T GetPrefab<T>() where T : Service
    {
        foreach(Service service in Instance.services)
        {
            if(typeof(T) == service.GetType())
            {
                return service as T;
            }
        }
        throw new ServiceNotFoundException<T>();
    }

    internal static T GetScriptableObject<T>() where T : ScriptableObject
    {
        foreach (ScriptableObject scriptableObject in Instance.scriptableObjects)
        {
            if (typeof(T) == scriptableObject.GetType())
            {
                return scriptableObject as T;
            }
        }
        throw new ServiceNotFoundException<T>();
    }

    static void CreateInstanceByType<T>() where T : Singleton<T>
    {
        Instantiate(GetPrefab<T>());
    }

    /// <summary>
    /// Creates Instance if there is no one
    /// </summary>
    /// <typeparam name="T">Type of the instance you want to create - Singleton<T></typeparam>
    internal static void CheckInstance<T>() where T : Singleton<T>
    {
        if (Singleton<T>.Instance == null)
        {
            CreateInstanceByType<T>();
        }
    }

    internal static T GetInstance<T>() where T : Singleton<T>
    {
        CheckInstance<T>();
        return Singleton<T>.Instance;
    }

#if UNITY_EDITOR
    public Service[] GetServices()
    {
        return services;
    }

    public void FindAndUpdateSingletones()
    {
        for (int i = 0; i < services.Length; i++)
        {
            if (services[i])
            {
                try
                {
                    services[i] = services[i].GetComponents<Service>().Single(s => s.GetType().BaseType.Name == ExpectedServiceBaseClassName());
                }
                catch (InvalidOperationException ex)
                {
                    Debug.LogError($"Most probable \"{services[i].name}\" doesn't contains Component derived from \"{ExpectedServiceBaseClassName()}\". {ex}");
                }
            }
        }
    }

    static string ExpectedServiceBaseClassName()
    {
        return typeof(Singleton<>).Name;
    }

    public void RemoveEmptyServices()
    {
        services = services.Where(s => s).ToArray();
    }
#endif
}
