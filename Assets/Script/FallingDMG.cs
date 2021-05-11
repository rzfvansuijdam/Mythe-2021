using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingDMG : MonoBehaviour
{
    public float timeInAir = 5;

    void Update()
    {
        //Here we decrease the time in air from 5
        //Grounded is used by Rigidbody controller
        if(!grounded)
            timeInAir -= 1 * Time.deltaTime;
   
 
        //Increase the time in air to reach 5 each time we're on ground
        if(grounded && timeInAir < 5 && timeInAir > 0)
            timeInAir = 5;
 
        //Making the player die when it reaches 0
        if(timeInAir <= 0)
            Debug.Log("You Died!");
 
        //Or just damage player on a "checkpoint", in this case I use 3
        if(timeInAir == 3 && grounded)
            Health.Lives -= 30;
 
    }
}
