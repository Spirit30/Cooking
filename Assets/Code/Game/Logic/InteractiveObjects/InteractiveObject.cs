using UnityEngine;

namespace GameLogic
{
    public class InteractiveObject : MonoBehaviour
    {
        [SerializeField]
        SpriteRenderer checkMark = null;

        [SerializeField]
        SpriteRenderer view = null;

        public SpriteRenderer View => view;

        public void ShowCheckMark(bool flag)
        {
            if (checkMark)
            {
                checkMark.gameObject.SetActive(flag);
            }
        }

        protected virtual void OnMouseDown()
        {
            GameController.Instance.OnInteractiveObject(this);
        }
    }
}