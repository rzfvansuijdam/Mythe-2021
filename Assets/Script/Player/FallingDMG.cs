using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    
    
    
    void Start() 
    {
        RidgedBody = GetComponent<Rigidbody>();
    }

    #region collsion
    
    
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "terrain")
        {
            grounded = true;
        }
        
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "terrain")
        {
            grounded = false;
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


        if (WillDie && grounded)
        {
            WillDie = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (WillLive && grounded)
        {
            WillLive = false;
            Health._lives = 10;
            print(Health._lives);
        }
        
    }

}

