using UnityEngine;

namespace GameData
{
    [CreateAssetMenu(fileName = nameof(GameConfig), menuName = "ScriptableObjects/" + nameof(GameConfig), order = 2)]
    public class GameConfig : ScriptableObject
    {
        public FoodConfig[] food = null;
    }
}