using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MedidorAngulo : MonoBehaviour
{
    Slider slider;
    private void Start()
    {
        slider = GetComponent<Slider>();
    }
    public int GetAngle()
    {
        return Mathf.RoundToInt( slider.value * 90);
    }
}
