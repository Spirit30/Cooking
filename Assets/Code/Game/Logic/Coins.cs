using GameData;
using GameView;
using GameView.UI;
using UnityEngine;

namespace GameLogic
{
    public class Coins : InteractiveObject
    {
        [SerializeField]
        PointsRewardView pointsRewardPrefab = null;

        protected override void OnMouseDown()
        {
            var config = LevelFactory.Instance.LevelConfig;

            int points = Random.Range(config.minPointsReward, config.maxPointsReward);
            var type = points < config.bigPointRewardThreshold ? PointsRewardType.Small : PointsRewardType.Big;
            Instantiate(pointsRewardPrefab, transform.position, transform.rotation).Init(points, type);
            PointsView.Instance.AddPoints(points);

            DestroyImmediate(gameObject);
        }
    }
}