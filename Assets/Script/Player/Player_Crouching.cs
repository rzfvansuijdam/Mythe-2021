using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player_Crouching : Player
{

    [SerializeField] private CapsuleCollider playerCol;

    public Action<bool> CrouchUpdated;

    Animator anim;

    void Start()
    {
        playerCol = GetComponent<CapsuleCollider>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        CrouchUpdated(_isCrouching);

        Vector3 rayPos = new Vector3(0, transform.localScale.y / 2, 0);

        if (Input.GetKeyDown(KeyCode.LeftControl) && !_isCrouching)
        {
            StartCoroutine("StartCrouching");
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl) && _isCrouching)
        {
            if (!Physics.BoxCast(transform.position, new Vector3(0.5f, 0.5f, 0.5f), transform.up + rayPos))
            {
                StartCoroutine("StopCrouching");
            }
        }

        anim.SetBool("IsCrouching", _isCrouching);
    }

    IEnumerator StartCrouching()
    {
        _isCrouching = true;
        //playerCol.height = 1.8f;
        yield return new WaitForSeconds(1f);
        yield return null;
    }

    IEnumerator StopCrouching()
    {
        _isCrouching = false;
        //transform.position -= new Vector3(0, 0.3f, 0);
        //playerCol.height = 1f;
        yield return null;
    }
}
