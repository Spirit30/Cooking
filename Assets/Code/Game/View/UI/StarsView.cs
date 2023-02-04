using GameData;
using UnityEngine;
using UnityEngine.UI;

namespace GameView
{
    public class StarsView : Singleton<StarsView>, IInitializable<int[]>
    {
        [SerializeField]
        Image progressBar = null;

        [SerializeField]
        RectTransform starsContainersPanel = null;

        [SerializeField]
        RectTransform[] starsContainers = null;

        [SerializeField]
        Image[] stars = null;

        int[] heartsForStars;
        int maxHeartsForStar;

        public int totalHearts;
        public float progress;

        public void Init(int[] heartsForStars)
        {
            this.heartsForStars = heartsForStars;
            maxHeartsForStar = heartsForStars.Last();

            for (int i = 0; i < heartsForStars.Length; ++i)
            {
                int heartsForStar = heartsForStars[i];
                var starContainer = starsContainers[i];

                float starNormalizedValue = (float)heartsForStar / maxHeartsForStar;
                var starContainerAnchoredPosition = starContainer.anchoredPosition;
                var starsContainersPanelWidth = starsContainersPanel.sizeDelta.x;
                starContainerAnchoredPosition.x = starNormalizedValue * starsContainersPanelWidth;
                starContainer.anchoredPosition = starContainerAnchoredPosition;
            }
        }

        public void AddHearts(int hearts)
        {
            totalHearts += hearts;
            progress = (float)totalHearts / maxHeartsForStar;
            UpdateStars();
        }

        void UpdateStars()
        {
            for (int i = 0; i < heartsForStars.Length; ++i)
            {
                int heartsForStar = heartsForStars[i];

                if (totalHearts >= heartsForStar)
                {
                    stars[i].gameObject.SetActive(true);
                    GameSession.Stars = i + 2;
                }
            }
        }

        void Update()
        {
            progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, progress, Time.deltaTime);
        }
    }
}