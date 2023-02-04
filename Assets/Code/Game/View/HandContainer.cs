using GameLogic;
using UnityEngine;

namespace GameView
{
    public class HandContainer : MonoBehaviour
    {
        [SerializeField]
        SpriteRenderer view = null;

        Food food;

        public bool HasFood => view.sprite;

        public bool HasFoodOfSameType(Food food)
        {
            return this.food.Config.id == food.Config.id;
        }

        public void TakeFood(Food food)
        {
            this.food = food;
            view.sprite = food.View.sprite;
            transform.localScale = food.View.transform.localScale / PlayerController.Instance.View.transform.localScale.y;
        }

        public void TryDropFood(Food food)
        {
            if(this.food && this.food.Config.id == food.Config.id)
            {
                DropFood();
            }
        }

        public void DropFood()
        {
            view.sprite = null;
        }
    }
}