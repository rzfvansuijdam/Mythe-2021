using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Crouching : Player
{

    private float standHeight = 2;
    private float crouchHeight = 1.3f;

    private bool isCrouching = false;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 rayPos = new Vector3(0, transform.localScale.y / 2, 0);

        if (Input.GetKeyDown(KeyCode.LeftControl) && !isCrouching)
        {
            StartCoroutine("StartCrouching");
        }
        if (Input.GetKeyUp(KeyCode.LeftControl) && isCrouching)
        {
            if (!Physics.BoxCast(transform.position, new Vector3(0.5f, 0.5f, 0.5f), transform.up + rayPos))
            {
                StartCoroutine("StopCrouching");
            }
        }
    }

    IEnumerator StartCrouching()
    {
        for (int i = 0; i < 50; i++)
        {
            transform.localScale -= new Vector3(0, (standHeight - crouchHeight) / 50, 0);
            transform.position -= new Vector3(0, (standHeight - crouchHeight) / 50, 0);
            yield return new WaitForSeconds(0.01f);
        }
        isCrouching = true;
        yield return null;
    }

    IEnumerator StopCrouching()
    {
        for (int i = 0; i < 50; i++)
        {
            transform.localScale += new Vector3(0, (standHeight - crouchHeight) / 50, 0);
            transform.position += new Vector3(0, (standHeight - crouchHeight) / 50, 0);
            yield return new WaitForSeconds(0.01f);
        }
        isCrouching = false;
        yield return null;
    }
}
