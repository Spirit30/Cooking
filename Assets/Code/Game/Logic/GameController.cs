using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameLogic
{
    public class GameController : Singleton<GameController>
    {
        PlayerController Character => PlayerController.Instance;

        public void OnInteractiveObject(InteractiveObject interactiveObject)
        {
            Character.TrySetPosition(interactiveObject.transform.position);
            StartCoroutine(ProcessInteractiveObject(interactiveObject));
        }

        public void Exit()
        {
            SceneManager.LoadScene("Home");
        }

        IEnumerator ProcessInteractiveObject(InteractiveObject interactiveObject)
        {
            interactiveObject.ShowCheckMark(true);
            yield return new WaitForEndOfFrame();
            //Character Start Move
            yield return new WaitWhile(IsCharacterMoving);
            //Character Stop Move
            interactiveObject.ShowCheckMark(false);

            if(interactiveObject is Food)
            {
                var food = (Food)interactiveObject;
                yield return ProcessFood(food);
            }
            else if(interactiveObject is Trash)
            {
                ProcessTrash();
            }
        }

        IEnumerator ProcessFood(Food food)
        {
            yield return food.Prepare();
            Character.TryTakeFood(food);
        }

        void ProcessTrash()
        {
            Character.TryDropFood();
        }

        bool IsCharacterMoving()
        {
            return Character.View.IsMove;
        }
    }
}
