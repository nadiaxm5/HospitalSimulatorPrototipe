using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChaosBar : MonoBehaviour
{
    public Slider slider;

    private void Start()
    {
        slider.value = 20f;
    }

    public void SetChaos(float chaos)
    {
        slider.value += chaos;
    }

    public float getChaosValue()
    {
        return slider.value;
    }

}
