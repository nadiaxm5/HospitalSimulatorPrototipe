using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
    public int money;
    public TextMeshProUGUI text;

    // Update is called once per frame
    void Update()
    {
        text.text = money.ToString();
    }

    public void AddMoney(int m)
    {
        money += m;
    }
}
