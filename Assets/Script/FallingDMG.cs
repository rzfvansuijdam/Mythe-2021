using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingDMG : MonoBehaviour
{

    public bool grounded;
    public float timeInAir = 5;

    private void Start()
    {

    }

    private void OnCollisionEnter(Collision Col)
    {
        if(Col.gameObject.name == "terrain")
        {
            grounded = false;
            Debug.Log("he touch my tralalal");
        }
        else
        {
            grounded = true;
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
        if (grounded == true && timeInAir < 3 && timeInAir > 0)
        {
            timeInAir = 3;
        }

        //Making the player die when it reaches 0
        if (timeInAir <= 0)
        {
            Debug.Log("You Died!");
            Health.Lives -= 100;
        }

        //Or just damage player on a "checkpoint", in this case I use 3
        if (timeInAir == 2 && grounded)
        {
            Health.Lives -= 30;
            Debug.Log("many pain");
        }
    }
}
