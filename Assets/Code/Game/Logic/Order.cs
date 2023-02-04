using GameView;
using GameView.UI;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class Order : InteractiveObject, IInitializable<Visitor, Food, float[]>
    {
        [SerializeField]
        OrderView uiView = null;

        Visitor visitor;
        Food food;

        Stack<float> waitTime;
        float waitTimer;

        public void Init(Visitor visitor, Food food, float[] waitTime)
        {
            this.visitor = visitor;
            this.food = food;
            this.waitTime = new Stack<float>(waitTime);
            ResetWaitTime();
            uiView.SetFood(food.View.sprite);
        }

        protected override void OnMouseDown()
        {
            base.OnMouseDown();

            if(PlayerController.Instance.IsCarryFood(food))
            {
                OnOrderSuccess();
            }
        }

        void Update()
        {
            waitTimer -= Time.deltaTime;

            uiView.UpdateHeart(waitTime.Count - 1, waitTimer, waitTime.Peek());

            if (waitTimer <= 0)
            {
                waitTime.Pop();
                visitor.View.DecreaseEmotion(waitTime.Count);

                if (waitTime.Count > 0)
                {
                    ResetWaitTime();
                }
                else
                {
                    OnOrderFail();
                }
            }
        }

        void ResetWaitTime()
        {
            waitTimer = waitTime.Peek();
        }

        void OnOrderSuccess()
        {
            enabled = false;

            PlayerController.Instance.TryDropFood(food);

            StarsView.Instance.AddHearts(waitTime.Count);
            uiView.ShowHeartsRewad();

            visitor.View.MakeHappy();
            visitor.GiveReward();
            visitor.Exit();

            Destroy(gameObject, uiView.HeartsRewardLength);
        }

        void OnOrderFail()
        {
            visitor.Exit();

            DestroyImmediate(gameObject);
        }
    }
}