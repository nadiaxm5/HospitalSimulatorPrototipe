using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatesController : MonoBehaviour
{
    public void DecreaseState(float state)
    {
        state -= 10f;
        ClampState(state);
    }

    public void IncreaseState(float state)
    {
        state += 10f;
        ClampState(state);
    }

    private void ClampState(float state)
    {
        state = Mathf.Clamp(state, 0f, 100f);
    }

}
