using UnityEngine;

namespace GameView
{
    public class VisitorView : MonoBehaviour, IInitializable<int>
    {
        [SerializeField]
        SpriteRenderer face = null;

        [SerializeField]
        Sprite happyEmotion = null;

        [SerializeField]
        Sprite[] faceEmotions = null;

        public void Init(int sortingLayerIndex)
        {
            foreach(var spriteRenderer in GetComponentsInChildren<SpriteRenderer>())
            {
                spriteRenderer.sortingLayerName = "Visitor" + sortingLayerIndex;
            }
        }

        public void MakeHappy()
        {
            face.sprite = happyEmotion;
        }

        public void DecreaseEmotion(int hearts)
        {
            face.sprite = faceEmotions[hearts];
        }
    }
}