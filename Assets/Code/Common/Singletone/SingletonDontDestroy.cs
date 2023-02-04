using UnityEngine;

public class SingletonDontDestroy<T> : Singleton<T> where T : MonoBehaviour
{
    protected override void Awake()
    {
        base.Awake();

        if (Instance == this)
        {
            DontDestroyOnLoad(gameObject);
            Debug.Log($"DontDestroyOnLoad Singleton: {name}");
        }
    }
}