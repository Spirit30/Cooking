using GameLogic;
using System.Linq;
using UnityEngine;

namespace GameData
{
    public class LevelMatrix : Singleton<LevelMatrix>
    {
        [SerializeField]
        Transform[] foodSockets = null;

        [SerializeField]
        Transform[] visitorSockets = null;

        [SerializeField]
        Transform[] coinsSockets = null;

        [SerializeField]
        Transform[] coinsRewardPath = null;

        public Transform[] FoodSockets => foodSockets;
        public Transform[] CoinsRewardPath => coinsRewardPath;

        public bool TryGetRandomVisitorSocket(out Transform visitorSocketResult)
        {
            foreach (var visitorSocket in visitorSockets.OrderBy(x => Random.value))
            {
                if (visitorSocket.childCount == 0)
                {
                    visitorSocketResult = visitorSocket;
                    return true;
                }
            }

            visitorSocketResult = null;
            return false;
        }

        public Transform GetCoinsSocket(Visitor visitor)
        {
            for (int i = 0; i < visitorSockets.Length; ++i)
            {
                var visitorSocket = visitorSockets[i];

                if (visitorSocket.childCount > 0 && visitorSockets[i].GetChild(0) == visitor.transform)
                {
                    return coinsSockets[i];
                }
            }

            throw new System.Exception("Coins Socket Not found.");
        }
    }
}