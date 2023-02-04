using GameLogic;
using System.Collections.Generic;
using UnityEngine;

namespace GameView
{
    public class CharacterView : MonoBehaviour
    {
        [SerializeField] 
        List<HandContainer> handContainers = new List<HandContainer>();

        [SerializeField]
        Animator animator = null;

        [SerializeField]
        string isMoveAnimationKey = "isRun";

        Vector3 initialOffset;
        Quaternion initialRotation;
        Vector3 initialScale;

        public float LookSign { get; set; }
        public bool IsMove { get; private set; }

        public bool TryGetHandContainer(out HandContainer handContainerResult)
        {
            foreach (var handContainer in handContainers)
            {
                if (!handContainer.HasFood)
                {
                    handContainerResult = handContainer;
                    return true;
                }
            }

            handContainerResult = null;
            return false;
        }

        public bool TryDropFood()
        {
            foreach(var handContainer in handContainers)
            {
                if(handContainer.HasFood)
                {
                    handContainer.DropFood();
                    return true;
                }
            }

            return false;
        }

        public void TryDropFood(Food food)
        {
            foreach (var handContainer in handContainers)
            {
                handContainer.TryDropFood(food);
            }
        }

        void Awake()
        {
            initialOffset = transform.position - transform.root.position;
            initialRotation = transform.rotation;
            initialScale = transform.localScale;
        }

        void Update()
        {
            //Position to center of Character Container
            Vector3 position = transform.root.position + initialOffset;
            Vector3 delta = transform.position - position;

            IsMove = delta != Vector3.zero;
            animator.SetBool(isMoveAnimationKey, IsMove);

            if (IsMove)
            {
                //Look to direction of movement
                var scale = new Vector3(initialScale.x * LookSign, initialScale.y, initialScale.z);

                //Apply
                transform.SetPositionAndRotation(position, initialRotation);
                transform.localScale = scale;
            }
        }
    }
}