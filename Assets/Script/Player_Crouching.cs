using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player_Crouching : Player
{

    private float standHeight = 2;
    private float crouchHeight = 1.3f;

    public Action<bool> CrouchUpdated;

    void Start()
    {
        
    }

    void Update()
    {
        CrouchUpdated(_isCrouching);

        Vector3 rayPos = new Vector3(0, transform.localScale.y / 2, 0);

        if (Input.GetKeyDown(KeyCode.LeftControl) && !_isCrouching)
        {
            StartCoroutine("StartCrouching");
        }
        if (Input.GetKeyUp(KeyCode.LeftControl) && _isCrouching)
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
        _isCrouching = true;
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
        _isCrouching = false;
        yield return null;
    }
}
