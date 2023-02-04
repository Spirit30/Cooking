using UnityEngine;
using UnityEngine.UI;

public class MultiImageButton : Button
{
	Graphic[] cachedGraphics;

	protected override void Start()
	{
		cachedGraphics = GetComponentsInChildren<Graphic>();
	}

	protected override void DoStateTransition(SelectionState state, bool instant)
    {
        var targetColor =
            state == SelectionState.Disabled ? colors.disabledColor :
            state == SelectionState.Highlighted ? colors.highlightedColor :
            state == SelectionState.Normal ? colors.normalColor :
            state == SelectionState.Pressed ? colors.pressedColor :
            state == SelectionState.Selected ? colors.selectedColor : Color.white;

		if (cachedGraphics != null)
		{
			foreach (var graphic in cachedGraphics)
			{
				graphic.CrossFadeColor(targetColor, instant ? 0f : colors.fadeDuration, true, true);
			}
		}
    }
}