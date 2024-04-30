using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    //Este código tiene muchos parches pero funciona
    [SerializeField] TextMeshProUGUI text;
    private int number; //Número del inventario
    public int id;
    public int realNumber; //El número de productos que hay en las estanterias

    private void Awake()
    {
        realNumber = GlobalVariables.realNumbers[id];
        number = 0;
    }

    private void Update()
    {
        ChangeColor();
        Debug.Log(id + GlobalVariables.realNumbers[id]);
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
