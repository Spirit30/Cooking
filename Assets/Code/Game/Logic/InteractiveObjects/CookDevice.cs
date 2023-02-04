using GameData;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameLogic
{
    public class CookDevice : InteractiveObject
    {
        [SerializeField]
        List<string> whatCanCoock = null;

        [SerializeField]
        Food food = null;

        bool isCooking;

        protected override void OnMouseDown()
        {
            base.OnMouseDown();

            if(isCooking)
            {
                return;
            }

            var foodWhichCanCook = PlayerController.Instance.CarryFood.FirstOrDefault(f => whatCanCoock.Contains(f.Config.id));

            if (foodWhichCanCook)
            {
                isCooking = true;

                PlayerController.Instance.TryDropFood(foodWhichCanCook);

                food.Init(foodWhichCanCook.Config);
                food.View.sprite = foodWhichCanCook.View.sprite;

                GameController.Instance.OnInteractiveObject(food);

                StartCoroutine(Cooking());
            }
        }

        bool IsPlayerGotFood()
        {
            return PlayerController.Instance.IsCarryFood(food);
        }

        IEnumerator Cooking()
        {
            food.Init(new FoodConfig());

            yield return new WaitUntil(IsPlayerGotFood);

            food.View.sprite = null;

            isCooking = false;
        }
    }
}