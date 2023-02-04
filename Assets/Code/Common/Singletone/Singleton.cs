using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance { get; private set; }

    protected virtual void Awake()
    {
        //If there already is a instance of this singleton we should destroy this one since there should only be 1 at anytime.
        if (Instance && Instance != this)
        {
            DestroyImmediate(gameObject);
            return;
        }

        Instance = this as T;

        name += $" {gameObject.scene.name}";
    }
}
