using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarManager : MonoBehaviour
{
    public Slider chaosSlider;
    public Slider patientSlider;
    public Slider coworkerSlider;

    int decision = 1;

    private void Start()
    {
        chaosSlider.value = 20f;
    }

    public void MakeDecision(int opcion)
    {
        switch (decision)
        {
            case 1:
                if(opcion == 0)
                {
                    AddChaos(-10);
                }
                else if(opcion == 1)
                {
                    AddChaos(-10);
                    AddHappinessPatient(-10);
                }
                else
                {
                    AddChaos(-10);
                    AddHappinessCoworkers(-10);
                }
                break;
            default:
                break;
        }
        decision++;
    }

    public void AddChaos(float chaos)
    {
        chaosSlider.value += chaos;
    }
    public void AddHappinessPatient(float happiness)
    {
        patientSlider.value += happiness;
    }
    public void AddHappinessCoworkers(float happiness)
    {
        coworkerSlider.value += happiness;
    }

    public void SetChaos(float chaos)
    {
        chaosSlider.value = chaos;
    }
    public void SetHappinessPatient(float happiness)
    {
        patientSlider.value = happiness;
    }
    public void SetHappinessCoworkers(float happiness)
    {
        coworkerSlider.value = happiness;
    }

    public float getChaosValue()
    {
        return chaosSlider.value;
    }
    public float getHappinessPatientValue()
    {
        return patientSlider.value;
    }
    public float getHappinessPatientCoworkersValue()
    {
        return coworkerSlider.value;
    }

}
