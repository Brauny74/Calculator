using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CalcApp;

public class GameController : MonoBehaviour
{
    public delegate void UpdateResultHandler(double NewResult);
    public static event UpdateResultHandler OnUpdateResult;

    private void OnEnable()
    {
        CalculateButton.OnButtonClick += CalculateFromString;
    }

    private void OnDisable()
    {
        CalculateButton.OnButtonClick -= CalculateFromString;
    }

    private void CalculateFromString(string s)
    {
        CalcResult calcResult = Calculator.RunExpression(s);
        if (!calcResult.Error)
        {
            Debug.Log(calcResult.Result);
            OnUpdateResult?.Invoke(calcResult.Result);
        }
        else
        {
            Debug.LogError(calcResult.Status);
        }
    }
}
