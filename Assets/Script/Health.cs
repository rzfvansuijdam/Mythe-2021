using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public static float Lives = 100f;
    private bool touchingEnemy = false;

    private void Update()
    {
        if (Input.GetKey("space"))
        {
            Debug.Log(Lives);
        }

        if (Lives <= 0f)
        {
            Death();
        }

        if (touchingEnemy == true)
        {
            Health.Lives -= 10;
            print(Lives);
        }
        
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Enemy")
        {
            touchingEnemy = true;
            print("T");
        }
    }

    public void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
}
