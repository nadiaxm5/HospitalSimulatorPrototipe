using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SupermarketManager : MonoBehaviour
{
    //Este código tiene muchos parches pero funciona
    public enum Type
    {
        Inventario,
        Ordenador
    }
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] GameObject[] products;
    [SerializeField] SupermarketManager supermarketManager;
    private int number; //Número del inventario
    public int realNumber; //El número de productos que hay en las estanterias
    private int buyNumber; //Número de productos que se van a comprar
    public Type type;
    
    private void Start()
    {
        number = 0;
        buyNumber = 0;
        for (int i = 0; i < products.Length; i++)
        {
            products[i].SetActive(false);
        }
    }

    private void Update()
    {
        if(type == Type.Inventario)
            ChangeColor();
    }

    public void AddNumberInventory()
    {
        if(number < 99)
        {
            number++;
            text.text = number.ToString();
        }
    }

    public void DecreaseNumberInventory()
    {
        if(number > 0)
        {
            number--;
            text.text = number.ToString();
        }
    }

    public void AddNumberPC()
    {
        if (buyNumber < 99)
        {
            buyNumber++;
            text.text = buyNumber.ToString();
        }
    }

    public void DecreaseNumberPC()
    {
        if (buyNumber > 0)
        {
            buyNumber--;
            text.text = buyNumber.ToString();
        }
    }

    public void BuyProducts()
    {
        if (supermarketManager.realNumber + buyNumber > products.Length)
            buyNumber = products.Length - supermarketManager.realNumber; //Para que no de out of range
        for(int i = supermarketManager.realNumber; i < supermarketManager.realNumber + buyNumber; i++)
        {
            products[i].SetActive(true);
        }
        supermarketManager.realNumber += buyNumber;
        Debug.Log(supermarketManager.realNumber);
    }

    public void ChangeColor()
    {
        if (number == realNumber)
            text.color = Color.white;
        else
            text.color = Color.red;
    }
}
