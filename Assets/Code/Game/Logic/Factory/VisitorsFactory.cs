using GameData;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class VisitorsFactory : Singleton<VisitorsFactory>, IInitializable<int>
    {
        [SerializeField]
        Visitor visitorPrefab = null;

        [SerializeField]
        float minRandomDiapason = 1;

        [SerializeField]
        float maxRandomDiapason = 3;

        int maxVisitors;

        List<Visitor> visitors = new List<Visitor>();

        public void Init(int maxVisitors)
        {
            this.maxVisitors = maxVisitors;
        }

        public void OnVisitorExit(Visitor visitor)
        {
            visitors.Remove(visitor);
            TrySpawnVisitor();
        }

        IEnumerator Start()
        {
            yield return new WaitForEndOfFrame();

            for (int i = 0; i < maxVisitors; ++i)
            {
                TrySpawnVisitor();
                float randomDiapason = Random.Range(minRandomDiapason, maxRandomDiapason);
                yield return new WaitForSeconds(randomDiapason);
            }
        }

        void TrySpawnVisitor()
        {
            if (visitors.Count < maxVisitors && LevelMatrix.Instance.TryGetRandomVisitorSocket(out Transform visitorSocket))
            {
                var visitor = Instantiate(visitorPrefab, visitorSocket);
                visitor.transform.ResetLocal();
                visitor.View.Init(visitors.Count);
                visitors.Add(visitor);
            }
        }
    }
}