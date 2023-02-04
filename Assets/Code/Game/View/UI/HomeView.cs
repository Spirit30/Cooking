using GameData;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GameView.UI
{
    public class HomeView : SingleButtonView
    {
        [SerializeField]
        Image[] stars = null;

        [SerializeField]
        Text points = null;

        protected override void Start()
        {
            base.Start();

            for(int i = 0; i < GameSession.Stars; ++i)
            {
                stars[i].gameObject.SetActive(true);
            }

            points.text = $"Score: {GameSession.Points}";
        }

        protected override void OnClick()
        {
            SceneManager.LoadScene("Level1");
        }
    }
}