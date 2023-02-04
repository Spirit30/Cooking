using GameView.UI;
using UnityEngine;

namespace GameLogic
{
    class TimeController : Singleton<TimeController>, IInitializable<float>
    {
        float timer;
        float Timer
        {
            get => timer;
            set
            {
                timer = value;
                OnChangeTime();
            }
        }

        public void Init(float time)
        {
            Timer = time;
        }

        void Update()
        {
            Timer -= Time.deltaTime;
        }

        void UpdateView()
        {
            TimeView.Instance.SetTime(Timer);
        }

        void OnChangeTime()
        {
            if (Timer > 0)
            {
                UpdateView();
            }
            else
            {
                GameController.Instance.Exit();
            }
        }
    }
}