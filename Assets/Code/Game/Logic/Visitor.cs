using GameView;
using System.Collections;
using UnityEngine;

namespace GameLogic
{
    public class Visitor : MonoBehaviour
    {
        [SerializeField]
        VisitorView view = null;

        [SerializeField]
        Animator animator = null;

        [SerializeField]
        Transform orderContainer = null;

        public VisitorView View => view;
        public Transform OrderContainer => orderContainer;
        float CurrentAnimationLength => animator.GetCurrentAnimatorStateInfo(0).length;

        public void GiveReward()
        {
            CoinsFactory.Instance.CreateCoins(this);
        }

        public void Exit()
        {
            VisitorsFactory.Instance.OnVisitorExit(this);
            animator.Play("VisitorExit");
            Destroy(gameObject, CurrentAnimationLength);
        }

        IEnumerator Start()
        {
            yield return new WaitForSeconds(CurrentAnimationLength);
            OrdersFactory.Instance.CreateOrder(this);
        }
    }
}