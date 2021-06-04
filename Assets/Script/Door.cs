using System;
using System.Collections;
using UnityEngine;


public class Door : MonoBehaviour
{
    //private GameObject DoorButton;
    private GameObject _Door;
    public float smooth = 10f;

    private bool _CanCloseDoor;
    private bool _CanOpenDoor;
    private bool _DoorIsOpen;
    private bool _DoorIsClosed;
    private bool _HasKey;

    private void Start()
    {
        _Door = GameObject.Find("door");
        _HasKey = false;
    }

    private void Update()
    {
        if (_CanOpenDoor && _HasKey && Input.GetKey(KeyCode.E))
        {
            Vector3 dir = Vector3.RotateTowards(transform.forward, transform.right * 6, 5 * Time.deltaTime, 6.0f);
            _Door.transform.rotation = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z));
            _DoorIsOpen = true;
            _CanCloseDoor = true;
        }

        if (_CanCloseDoor && Input.GetKey(KeyCode.E))
        {
            Vector3 dir = Vector3.RotateTowards(transform.forward, -transform.right * -6, 5 * Time.deltaTime, 6.0f);
            _Door.transform.rotation = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z));   
        }
        
    }

    private void OnTriggerEnter(Collider key)
    {
        if (key.gameObject.tag == "key")
        {
            _HasKey = true;
            print("has key");
        }
    }

    private void OnCollisionEnter(Collision door)
    {
        if (door.gameObject.name == "door")
        {
            print("is at door");
            _CanOpenDoor = true;
        }
    }
    
     

}
