using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingDMG : MonoBehaviour
{

    public bool grounded;
    public float timeInAir = 5;
    public float DMGCheckpoint;
    public float MaxTime;
    
    
    


    
    
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name != "terrain")
        {
            grounded = true;
            Debug.Log("1");
        }
        else 
        {
            grounded = false;
            Debug.Log("2");
        }
        
    }
    
    
    void Update()
    {
        #region timer
        //Here we decrease the time in air from 5
        if (grounded == false)
        {
            timeInAir -= 1 * Time.deltaTime;
           // Debug.Log("midair");
        }
        #endregion
        
        #region reset_timer
        //Increase the time in air to reach Max allowed time each time we're on ground
        if (grounded == true && timeInAir < MaxTime && timeInAir > 0)
        {
            timeInAir = MaxTime;
        }
        #endregion
        
        #region death
        //Making the player die when it reaches 0
        if (timeInAir <= 0)
        {
            Debug.Log("You Died!");
            Health.Lives -= 100;
        }
        #endregion
        
        #region damage
        //Or just damage player on a "checkpoint", in this case I use 3
        if (timeInAir == DMGCheckpoint && grounded)
        {
            Health.Lives -= 30;
            Debug.Log("many pain");
        }
        #endregion
    }
}
