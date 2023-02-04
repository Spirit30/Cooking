using UnityEngine;

namespace GameLogic
{
    public class OrdersFactory : Singleton<OrdersFactory>
    {
        [SerializeField]
        Order orderPrefab = null;

        public void CreateOrder(Visitor visitor)
        {
            var order = Instantiate(orderPrefab, visitor.OrderContainer);
            order.transform.ResetLocal();

            order.Init(
                visitor,
                LevelFactory.Instance.Food.GetRandomItem(), 
                LevelFactory.Instance.LevelConfig.orderWaitTime);
        }
    }
}