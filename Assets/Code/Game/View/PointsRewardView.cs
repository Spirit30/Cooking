using GameData;
using UnityEngine;
using UnityEngine.UI;

namespace GameView
{
    public class PointsRewardView : MonoBehaviour, IInitializable<int, PointsRewardType>
    {
        [SerializeField]
        Text[] lables = null;

        [SerializeField]
        TrailRenderer[] trails = null;

        [SerializeField]
        float speed = 10.0f;

        [SerializeField]
        float destroyTime = 2.0f;

        Transform[] path;

        int currentPointIndex = 0;

        public void Init(int points, PointsRewardType type)
        {
            int index = (int)type;
            lables[index].text = $"+{points}";
            lables[index].gameObject.SetActive(true);
            trails[index].gameObject.SetActive(true);
        }

        public void Start()
        {
            path = LevelMatrix.Instance.CoinsRewardPath;

            float minDist = float.MaxValue;

            for(int i = 0; i < path.Length; ++i)
            {
                float dist = Vector3.Distance(path[i].position, transform.position);

                if (dist < minDist)
                {
                    minDist = dist;
                    currentPointIndex = i;
                }
            }
        }

        void Update()
        {
            if (currentPointIndex < path.Length)
            {
                var destination = path[currentPointIndex].position;
                float dist = Vector3.Distance(transform.position, destination);

                if (dist > 0.1f)
                {
                    transform.position = Vector3.Lerp(transform.position, destination, Time.deltaTime * speed / dist);
                }
                else
                {
                    ++currentPointIndex;
                }
            }
            else
            {
                enabled = true;
                Destroy(gameObject, destroyTime);
            }
        }
    }
}