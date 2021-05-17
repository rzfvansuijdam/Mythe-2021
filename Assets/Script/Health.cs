using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public static float Lives = 100f;

    private void Update()
    {
        if (Input.GetKey("space"))
        {
            Debug.Log(Lives);
        }

        if (Lives <= 0f)
        {
          //  Debug.Log("got em");
          //  Destroy(gameObject);
        }
    }
}
