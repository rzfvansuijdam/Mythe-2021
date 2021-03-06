using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Pickup : Player
{

    private bool IsAtItem;
    private bool isAtDropoff;
    
    private GameObject item;
    private List<string> Inventory = new List<string>();
    
    
    public Action<int> CurrencyUpdated;
    
    public static Dictionary<string, int> ItemValues = new Dictionary<string, int>
    {
        {"Item_coin", 100},
        {"Item_vase", 500}
    };

    void Update()
    {
        if (isAtDropoff && Input.GetKey(KeyCode.E)/* && Inventory.Count != 0*/)
        {
            SceneManager.LoadScene("Goodjoblad");
        }else if (IsAtItem && Input.GetKeyDown(KeyCode.E))
        {
            Inventory.Add(item.name);
            Destroy(item);
            IsAtItem = false;
        }
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
        if (collision.tag == "coin")
        {
            IsAtItem = false;
            isAtDropoff = false;
            item = null;
        }
    }
    void Loadscene()
    {
        
    }

}
