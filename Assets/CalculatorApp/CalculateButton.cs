using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateButton : MonoBehaviour
{
    public delegate void ButtonClickHandler(string NewExpression);
    public static event ButtonClickHandler OnButtonClick;
    public UnityEngine.UI.InputField ExpressionInput;

    public void OnClick()
    {
        OnButtonClick?.Invoke(ExpressionInput.text);
    }
}
