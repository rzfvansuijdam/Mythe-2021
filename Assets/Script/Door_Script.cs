using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Door_Script : MonoBehaviour
{
    private bool CanOpenDoor;
    private bool DoorIsOpen;
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
        DoorIsOpen = false;
    }


    
    private void Update()
    {

        
        if (CanOpenDoor && Input.GetKey(KeyCode.E))
        {
         //   anime.Play("doorleft");
        // transform.rotation = Vector3(0, 90, 0);
            CanOpenDoor = false;
            DoorIsOpen = true;

        }

        if (DoorIsOpen && Input.GetKey(KeyCode.E))
        {
          //  anime.Play("doorright");
            print("closing door");
            DoorIsOpen = false;
            CanOpenDoor = true;
        }
    }
}
