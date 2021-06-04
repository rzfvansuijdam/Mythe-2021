using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainDoor : MonoBehaviour
{

    private bool _CanOpenDoor;

    void Start()
    {
        _CanOpenDoor = false;
    }



    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "MainDoor")
        {
            _CanOpenDoor = true;
            print("door");
        }

    }

    void Update()
    {
        
        if (_CanOpenDoor && Input.GetKey(KeyCode.E))
        {
            SceneManager.LoadScene("Goodjoblad");
        }
    }
}
