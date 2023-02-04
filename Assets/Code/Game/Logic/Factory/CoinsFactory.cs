using GameData;
using UnityEngine;

namespace GameLogic
{
    public class CoinsFactory : Singleton<CoinsFactory>
    {
        [SerializeField]
        Coins coinsPrefab = null;

        public void CreateCoins(Visitor visitor)
        {
            var coins = Instantiate(coinsPrefab, LevelMatrix.Instance.GetCoinsSocket(visitor));
            coins.transform.ResetLocal();
        }
    }
}