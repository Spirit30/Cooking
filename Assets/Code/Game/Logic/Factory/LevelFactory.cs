using GameData;
using GameView;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class LevelFactory : Singleton<LevelFactory>
    {
        [SerializeField]
        GameConfig gameConfig = null;

        [SerializeField]
        LevelConfig levelConfig = null;

        public LevelConfig LevelConfig => levelConfig;

        public List<Food> Food { get; } = new List<Food>();

        int currentIndex;

        void Start()
        {
            TimeController.Instance.Init(levelConfig.time);
            VisitorsFactory.Instance.Init(levelConfig.maxVisitors);
            StarsView.Instance.Init(levelConfig.heartsForStar);
            InitFood();
        }

        void InitFood()
        {
            for (int i = 0; i < LevelMatrix.Instance.FoodSockets.Length; ++i)
            {
                var config = gameConfig.food.Next(ref currentIndex);
                var socket = LevelMatrix.Instance.FoodSockets[i];
                var food = Instantiate(config.prefab, socket);
                food.Init(config);
                Food.Add(food);
            }
        }
    }
}