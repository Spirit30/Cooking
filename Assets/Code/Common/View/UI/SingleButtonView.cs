using UnityEngine.Events;

namespace GameView.UI
{
    public abstract class SingleButtonView : UIView
    {
        protected override UnityAction[] GetButtonActions()
        {
            return new UnityAction[]
            {
                OnClick
            }; 
        }

        protected abstract void OnClick();
    }
}