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

        if (Lives <= 0f)
        {
            GameOver();
        }

        if (touchingEnemy == true)
        {
            Health.Lives -= 10;
        }
        
    }

    private void OnCollisionEnter(Collision Enem)
    {
        if (Enem.gameObject.tag == ("enemy"))
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }


}
