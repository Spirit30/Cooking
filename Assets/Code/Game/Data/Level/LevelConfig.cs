using UnityEngine;

namespace GameData
{
    [CreateAssetMenu(fileName = nameof(LevelConfig), menuName = "ScriptableObjects/" + nameof(LevelConfig), order = 1)]
    public class LevelConfig : ScriptableObject
    {
        public float time = 45;
        public int maxVisitors = 4;
        public float[] orderWaitTime =
        {
            5, 4, 3
        };
        public int[] heartsForStar =
        {
            3, 21
        };
        public int minPointsReward = 500;
        public int maxPointsReward = 2500;
        public int bigPointRewardThreshold = 2000;
        public int penaltyPoints = 150;
    }
}