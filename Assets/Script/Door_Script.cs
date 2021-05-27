using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Door_Script : MonoBehaviour
{
    private bool CanOpenDoor;
    private GameObject _Door;
    private Animation anime;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CanOpenDoor = true;
        }

    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            CanOpenDoor = false;
        }
    }

    private void Start()
    {
        anime = gameObject.GetComponent<Animation>();
     //   anime["door"].layer = 123;
    }

    private void Update()
    {

        
        if (CanOpenDoor && Input.GetKey(KeyCode.E))
        {
            print("opensaysme");
            anime.Play("notdoor");
          
            
        }
    }
}
