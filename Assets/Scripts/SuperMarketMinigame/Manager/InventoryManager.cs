using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    //Este c�digo tiene muchos parches pero funciona
    [SerializeField] TextMeshProUGUI text;
    private int number; //N�mero del inventario
    public int realNumber; //El n�mero de productos que hay en las estanterias

    private void Start()
    {
        number = 0;
    }

    private void Update()
    {
        ChangeColor();
    }

    public void AddNumberInventory()
    {
        if (number < 99)
        {
            number++;
            text.text = number.ToString();
        }
    }

    public void DecreaseNumberInventory()
    {
        if (number > 0)
        {
            number--;
            text.text = number.ToString();
        }
    }

    public void ChangeColor()
    {
        if (number == realNumber)
            text.color = Color.white;
        else
            text.color = Color.red;
    }
}