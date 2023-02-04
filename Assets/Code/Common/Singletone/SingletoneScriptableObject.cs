using UnityEngine;

public class SingletoneScriptableObject<T> : ScriptableObject where T : ScriptableObject
{
    static T instance;
    public static T Instance
    {
        get
        {
            if (!instance)
            {
                instance = ServiceLocator.GetScriptableObject<T>();
            }
            return instance;
        }
    }
}
