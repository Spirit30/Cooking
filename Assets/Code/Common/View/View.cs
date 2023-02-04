using UnityEngine;

namespace GameView
{
    public abstract class View : MonoBehaviour
    {
        public virtual bool IsActive => gameObject.activeInHierarchy;
        
        public void Activate(bool flag)
        {
            gameObject.SetActive(flag);
        }
    }
}