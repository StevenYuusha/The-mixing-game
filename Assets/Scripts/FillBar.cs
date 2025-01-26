using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillBar : MonoBehaviour
{

    public Slider slider;
    public void setMinValue()
    {
        slider.value = 0;
        slider.minValue = 0;
    }
    public void setMaxValue(int value)
    {
        slider.maxValue = value;
    }
    public void setFillValue(int value)
    {
        slider.value = value;
    }

}
