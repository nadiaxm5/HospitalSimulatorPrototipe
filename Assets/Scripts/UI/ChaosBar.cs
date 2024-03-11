using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChaosBar : MonoBehaviour
{
    public Slider slider;

    public void SetChaos(int chaos)
    {
        slider.value = chaos;
    }

}
