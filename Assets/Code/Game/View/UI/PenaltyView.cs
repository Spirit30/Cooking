using UnityEngine;
using UnityEngine.UI;

namespace GameView.UI
{
    public class PenaltyView : Singleton<PenaltyView>
    {
        [SerializeField]
        Text lable = null;

        [SerializeField]
        float viewTime = 2.0f;

        float timer;

        public void Open(int points)
        {
            lable.text = points.ToString();
            timer = viewTime;
            gameObject.SetActive(true);
        }

        protected override void Awake()
        {
            base.Awake();

            gameObject.SetActive(false);
        }

        void Update()
        {
            timer -= Time.deltaTime;

            if(timer < 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}