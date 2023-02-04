using GameView.UI;

namespace GameLogic
{
    public class Trash : InteractiveObject
    {
        protected override void OnMouseDown()
        {
            base.OnMouseDown();

            if (PlayerController.Instance.IsCarryFood())
            {
                int penalty = -LevelFactory.Instance.LevelConfig.penaltyPoints;

                PointsView.Instance.AddPoints(penalty);
                PenaltyView.Instance.Open(penalty);
            }
        }
    }
}