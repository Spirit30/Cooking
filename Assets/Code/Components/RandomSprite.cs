using UnityEngine;

namespace GameComponents
{
    public class RandomSprite : MonoBehaviour
    {
        [SerializeField]
        SpriteRenderer[] spriteRenderers = null;

        [SerializeField]
        Sprite[] variants = null;

        void Start()
        {
            var variant = variants.GetRandomItem();

            foreach(var spriteRenderer in spriteRenderers)
            {
                spriteRenderer.sprite = variant;
            }
        }
    }
}