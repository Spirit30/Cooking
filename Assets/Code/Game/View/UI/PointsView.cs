using GameData;
using UnityEngine;
using UnityEngine.UI;

namespace GameView.UI
{
    public class PointsView : Singleton<PointsView>
    {
        [SerializeField]
        Text lable = null;

        [SerializeField]
        Color negativeColor = Color.red;

        [SerializeField]
        float updateTime = 1.0f;

        int totalPoints;
        int totalPointsView;
        float updateTimer;

        public void AddPoints(int points)
        {
            totalPoints += points;
            GameSession.Points = totalPoints;

            lable.color = totalPoints >= 0 ? Color.white : negativeColor;

            updateTimer = 0.0f;
        }

        void Update()
        {
            updateTimer += Time.deltaTime;

            totalPointsView = Mathf.CeilToInt(Mathf.Lerp(totalPointsView, totalPoints, updateTimer / updateTime));

            lable.text = totalPointsView.ToString();
        }
    }
}