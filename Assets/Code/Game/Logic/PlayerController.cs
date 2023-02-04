using GameView;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

namespace GameLogic
{
    public class PlayerController : Singleton<PlayerController>
    {
        [SerializeField]
        NavMeshAgent navMeshAgent = null;

        [SerializeField]
        CharacterView characterView = null;

        public CharacterView View => characterView;

        List<Food> carryFood = new List<Food>();

        public IReadOnlyList<Food> CarryFood => carryFood;

        public void TrySetPosition(Vector3 position)
        {
            Vector3 delta = position - transform.position;
            View.LookSign = Mathf.Sign(delta.x);

            navMeshAgent.SetDestination(position);
        }

        public bool IsCarryFood()
        {
            return carryFood.Count > 0;
        }

        public bool IsCarryFood(Food food)
        {
            return carryFood.Any(f => f.Config.id == food.Config.id);
        }

        public void TryTakeFood(Food food)
        {
            if (View.TryGetHandContainer(out HandContainer handContainer))
            {
                carryFood.Add(food);
                handContainer.TakeFood(food);
            }
        }

        public void TryDropFood(Food food)
        {
            carryFood.Remove(food);
            View.TryDropFood(food);
        }

        public void TryDropFood()
        {
            if (View.TryDropFood())
            {
                carryFood.RemoveAt(0);
            }
        }
    }
}