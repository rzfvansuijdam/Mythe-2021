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

        Vector3 rayPos = new Vector3(0, transform.localScale.y / 4, 0);
        bool rayHit = Physics.BoxCast(transform.position, new Vector3(0.5f, 0.5f, 0.5f), transform.up * 0.1f, transform.rotation, 0.5f);

        if (Input.GetKeyDown(KeyCode.LeftControl) && !_isCrouching)
        {
            StartCoroutine("StartCrouching");
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl) && _isCrouching)
        {
            if (!rayHit)
            {
                StartCoroutine("StopCrouching");
            }
        }

        anim.SetBool("IsCrouching", _isCrouching);
    }

    IEnumerator StartCrouching()
    {
        _isCrouching = true;
        yield return new WaitForSeconds(1f);
        yield return null;
    }

    IEnumerator StopCrouching()
    {
        _isCrouching = false;
        yield return null;
    }
}
