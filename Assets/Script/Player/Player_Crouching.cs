using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player_Crouching : Player
{

    private float standHeight = 2;
    private float crouchHeight = 1.3f;

    [SerializeField] private CapsuleCollider playerCol;

    public Action<bool> CrouchUpdated;

    void Start()
    {
        playerCol = GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        CrouchUpdated(_isCrouching);

        Vector3 rayPos = new Vector3(0, transform.localScale.y / 2, 0);

        if (Input.GetKeyDown(KeyCode.LeftControl) && !_isCrouching && transform.localScale.y == 2)
        {
            StartCoroutine("StartCrouching");
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl) && _isCrouching && transform.localScale.y == 1.3f)
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
            playerCol.transform.localScale -= new Vector3(0, (standHeight - crouchHeight) / 50, 0);
            //transform.position -= new Vector3(0, (standHeight - crouchHeight) / 50, 0);
            yield return new WaitForSeconds(0.01f);
        }
        _isCrouching = true;
        playerCol.transform.localScale = new Vector3(transform.localScale.x, 1.3f, transform.localScale.z);
        yield return null;
    }

    IEnumerator StopCrouching()
    {
        for (int i = 0; i < 50; i++)
        {
            playerCol.transform.localScale += new Vector3(0, (standHeight - crouchHeight) / 50, 0);
            //transform.position += new Vector3(0, (standHeight - crouchHeight) / 50, 0);
            yield return new WaitForSeconds(0.01f);
        }
        _isCrouching = false;
        playerCol.transform.localScale = new Vector3(transform.localScale.x, 2f, transform.localScale.z);
        yield return null;
    }
}
