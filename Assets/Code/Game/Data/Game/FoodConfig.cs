using GameLogic;
using System;

namespace GameData
{
    [Serializable]
    public class FoodConfig : ObjectConfig
    {
        public int reward;
        public Food prefab;
    }
}