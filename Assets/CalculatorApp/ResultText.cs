using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultText : MonoBehaviour
{
    public UnityEngine.UI.Text UIText;

    private void OnEnable()
    {
        GameController.OnUpdateResult += SetUIText<double>;
    }

    private void OnDisable()
    {
        GameController.OnUpdateResult -= SetUIText<double>;
    }

    private void SetUIText<T>(T newData)
    {
        UIText.text = newData.ToString();
    }
}
