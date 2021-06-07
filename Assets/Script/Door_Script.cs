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

        DoorIsOpen = false;
    }



    private void Update()
    {
        
        


        if (CanOpenDoor && Input.GetKey(KeyCode.E))
        {
            StartCoroutine(WaitOpen());


        }
     
        if (DoorIsOpen && Input.GetKey(KeyCode.E))
        {
         //   StartCoroutine(WaitClose());
            
        }

    }
    private IEnumerator WaitOpen()
    {
        Vector3 Dir = Vector3.RotateTowards(transform.right, new Vector3(0, 90, 0), 5 * Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(new Vector3(Dir.x, 0, Dir.z));
        yield return new WaitForSeconds(3f);
        DoorIsOpen = true;
        print("open");
    }
 /*   private IEnumerator WaitClose()
    {
        Vector3 Dir = Vector3.RotateTowards(-transform.right, new Vector3(0, 180, 0), 5 * Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(new Vector3(Dir.x, 0, Dir.z));
        yield return new WaitForSeconds(3f);
        CanOpenDoor = true;
        print("not open");
    }

*/
}