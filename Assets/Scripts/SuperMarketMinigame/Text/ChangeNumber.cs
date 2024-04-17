using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeNumber : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    private int number;
    public int realNumber;
    private void Start()
    {
        number = 0;
    }

    private void Update()
    {
        if (number == realNumber)
            text.color = Color.green;
        else
            text.color = Color.red;
    }

    public void AddNumber()
    {
        if(number < 99)
        {
            number++;
            text.text = number.ToString();
        }
    }

    public void DecreaseNumber()
    {
        if(number > 0)
        {
            number--;
            text.text = number.ToString();
        }
    }
}
