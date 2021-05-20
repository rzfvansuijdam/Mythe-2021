using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Player_Pickup : Player
{

    private bool IsAtItem;
    private bool isAtDropoff;
    
    private GameObject item;
    private List<string> Inventory = new List<string>();
    
    private Text MyText;
    
    public Action<int> CurrencyUpdated;
    
    public static Dictionary<string, int> ItemValues = new Dictionary<string, int>
    {
        {"Item_coin", 100},
        {"Item_vase", 500}
    };
    
    void Start()
    {
        MyText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAtDropoff && Input.GetKey(KeyCode.E) && Inventory.Count != 0)
        {
            foreach (string i in Inventory)
            {
                _currency += ItemValues[i];

                Inventory.Remove(i);
            }
        }else if (IsAtItem && Input.GetKeyDown(KeyCode.E))
        {
            Inventory.Add(item.name);
            Destroy(item);
        }
        MyText.text = _currency.ToString();
    }
    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "coin")
        {
            IsAtItem = true;
            item = collision.gameObject;
        }
        
        if (collision.name == "dropoff")
        {
            isAtDropoff = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        IsAtItem = false;
        isAtDropoff = false;

    }
}
