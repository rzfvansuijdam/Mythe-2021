using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingDMG : MonoBehaviour
{
    
    public Vector3 Velocity;
    public Rigidbody RidgedBody;
    public bool IsAlive = true;
    private double _decelerationTolerance = 12.0;
    public bool grounded;
    public bool WillDie = false;
    public bool WillLive = false;
    public float DMGVelocity;
    public float DeathVelocity;

    #region code
    
/*

    public float timeInAir = 5;
    public float MaxTime;

    #region dont remove
    


    #endregion 

    //Or just damage player on a "checkpoint", in this case I use 3
    private void Damage()
    {
        Health.Lives -= 33f;
        print(Health.Lives);
    }



    void Update()

{
      
        //Here we decrease the time in air from 5
        if (grounded == false)
        {
            timeInAir -= 1 * Time.deltaTime;
           // Debug.Log("midair");
        }
     
 
        //Increase the time in air to reach Max allowed time each time we're on ground
        if (grounded == true && timeInAir < MaxTime && timeInAir > 0)
        {
            timeInAir = MaxTime;
        }
       
        
        
        //Making the player die when it reaches 0
        if (timeInAir <= 0)
        {
           Health.Lives -= 100f;
        }

        if ()
        {
            
        }
        
        if (timeInAir >= 2)
        {
            Damage();
        }
*/

    #endregion
    void Start() 
    {
        RidgedBody = GetComponent<Rigidbody>();
    }

    #region collsion
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "terrain")
        {
            grounded = false;
            print("false1");
        }

    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "terrain")
        {
            grounded = true;
            print("true");
        }
        
    }

    #endregion
    
    void FixedUpdate() 
    {
        if(IsAlive)
        {
            IsAlive = Vector3.Distance(RidgedBody.velocity, Velocity) < _decelerationTolerance;
            Velocity = RidgedBody.velocity;
            
        }

        if (RidgedBody.velocity.y <= DMGVelocity)
        {
            WillLive = true;
        }

        
        if (RidgedBody.velocity.y <= DeathVelocity)
        {
            WillDie = true;
        }


        if (grounded && WillDie)
        {
            print("u have died");
            WillDie = false;
        }

        if (grounded && WillLive)
        {
            print("u have been damaged");
            WillLive = false;
        }
        
    }

}

