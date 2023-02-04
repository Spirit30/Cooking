using UnityEngine;
using UnityEngine.UI;

namespace GameView.UI
{
    public class OrderView : MonoBehaviour
    {
        [SerializeField]
        Image foodImage = null;

        [SerializeField]
        Image[] hearts = null;

        [SerializeField]
        Animator animator = null;

        [SerializeField]
        AnimationClip heartsRewardAnimation = null;

        [SerializeField]
        ParticleSystem heartsParticlesPrefab = null;

        public float HeartsRewardLength => heartsRewardAnimation.length;

        ParticleSystem heartsParticles;

        public void SetFood(Sprite sprite)
        {
            foodImage.sprite = sprite;
        }

        public void UpdateHeart(int i, float timer, float time)
        {
            hearts[i].fillAmount = timer / time;
        }

        public void ShowHeartsRewad()
        {
            animator.enabled = true;
            heartsParticles = Instantiate(heartsParticlesPrefab, transform);
            heartsParticles.transform.ResetLocal();
        }
    }
}