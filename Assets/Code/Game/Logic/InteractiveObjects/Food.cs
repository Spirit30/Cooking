using GameData;
using GameView;
using System.Collections;
using UnityEngine;

namespace GameLogic
{
    public class Food : InteractiveObject, IInitializable<FoodConfig>
    {
        [SerializeField]
        ClockView clockView = null;

        [SerializeField]
        float prepareTime = 0;

        static readonly WaitForEndOfFrame frame = new WaitForEndOfFrame();

        public FoodConfig Config { get; private set; }
        public float PrepareTime => prepareTime;

        public void Init(FoodConfig foodConfig)
        {
            Config = foodConfig;
        }

        public IEnumerator Prepare()
        {
            clockView.Activate(true);

            float time = 0;

            while((time += Time.deltaTime) < prepareTime)
            {
                clockView.SetProgress(time / prepareTime);
                yield return frame;
            }

            clockView.SetProgress(1.0f);

            clockView.Activate(false);
        }
    }
}
