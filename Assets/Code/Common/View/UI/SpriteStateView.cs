using UnityEngine;
using UnityEngine.UI;

namespace GameView.UI
{
    public class SpriteStateView : MonoBehaviour
    {
        [SerializeField]
        Image targetImage = null;

        [SerializeField]
        Sprite[] sprites = null;

        public void SetState(bool isOn)
        {
            targetImage.sprite = sprites[isOn ? 1 : 0];
        }

        public void SetState(int stateIndex)
        {
            targetImage.sprite = sprites[stateIndex];
        }
    }
}