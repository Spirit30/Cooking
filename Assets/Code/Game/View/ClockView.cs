using UnityEngine;
using UnityEngine.UI;

namespace GameView
{
    public class ClockView : View
    {
        [SerializeField]
        Image progressImage = null;

        public void SetProgress(float progress)
        {
            progressImage.fillAmount = progress;
        }
    }
}