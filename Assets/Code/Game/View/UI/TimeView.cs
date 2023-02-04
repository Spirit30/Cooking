using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameView.UI
{
    class TimeView : Singleton<TimeView>
    {
        [SerializeField]
        Text timeText = null;

        public void SetTime(float timer)
        {
            var timeSpan = TimeSpan.FromSeconds(timer);
            //Format 00:00
            timeText.text = $"{timeSpan.Minutes:00}:{timeSpan.Seconds:00}";
        }
    }
}