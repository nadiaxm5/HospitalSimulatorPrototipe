using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PCManager : MonoBehaviour
{
    //Este código tiene muchos parches pero funciona
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] GameObject[] products;
    [SerializeField] InventoryManager inventory;
    [SerializeField] Money money;
    private int number; //Número de productos que se van a comprar
    public int price;
    
    private void Start()
    {
        number = 0;
        for (int i = 0; i < products.Length; i++)
        {
            products[i].SetActive(false);
        }
    }

    public void AddNumberPC()
    {
        if (number < 99)
        {
            number++;
            text.text = number.ToString();
        }
    }

    public void DecreaseNumberPC()
    {
        if (number > 0)
        {
            number--;
            text.text = number.ToString();
        }
    }

    public void BuyProducts()
    {
        if (inventory.realNumber + number > products.Length)
            number = products.Length - inventory.realNumber; //Para que no de out of range
        for(int i = inventory.realNumber; i < inventory.realNumber + number; i++)
        {
            products[i].SetActive(true);
            money.AddMoney(-price);
        }
        inventory.realNumber += number;
        number = 0;
        text.text = number.ToString();
    }
}
