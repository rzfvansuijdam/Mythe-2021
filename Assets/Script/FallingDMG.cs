using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingDMG : MonoBehaviour
{

    public bool grounded;
    public float timeInAir = 5;
    

    private void OnTriggerEnter(Collider Col)
    {
        if(Col.gameObject.name == "terrain")
        {
            grounded = true;
            Debug.Log("he touch my tralalal");
        }
        else
        {
            grounded = false;
            Debug.Log("he NOT touch my tralalal");
        }
    }


    void Update()
    {
        //Here we decrease the time in air from 5
        //Grounded is used by Rigidbody controller
        if (grounded == false)
        {
            timeInAir -= 1 * Time.deltaTime;
            Debug.Log("midair");
        }

        //Increase the time in air to reach 5 each time we're on ground
        if (grounded == true && timeInAir < 5 && timeInAir > 0)
        {
            timeInAir = 5;
        }

        //Making the player die when it reaches 0
        if (timeInAir <= 0)
        {
            Debug.Log("You Died!");
        }

        //Or just damage player on a "checkpoint", in this case I use 3
        if (timeInAir == 3 && grounded)
        {
            Health.Lives -= 30;
            Debug.Log("many pain");
        }
    }
}
