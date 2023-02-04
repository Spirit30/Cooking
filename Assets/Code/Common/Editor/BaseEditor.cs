using UnityEditor;
using UnityEngine;

public abstract class BaseEditor<T> : Editor where T : Object
{
    protected T Target => (T)target;

    public bool Confirm(string description)
    {
        return EditorUtility.DisplayDialog("Confirm", description, "Yes", "No");
    }
}
