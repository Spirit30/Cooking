using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameView.UI
{
    public abstract class UIView : View
    {
        [SerializeField] 
        protected Button[] buttons = null;

        protected virtual void Start()
        {
            if (buttons.Length > 0)
            {
                UnityAction[] buttonActions = GetButtonActions();

                Assert.AreEqual(buttons.Length, buttonActions.Length, "All assigned Buttons should have Actions.");

                for (int i = 0; i < buttons.Length; ++i)
                {
                    buttons[i].onClick.AddListener(buttonActions[i]);
                }
            }
        }

        protected abstract UnityAction[] GetButtonActions();
    }
}