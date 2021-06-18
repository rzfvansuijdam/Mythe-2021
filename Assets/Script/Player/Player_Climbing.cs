﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player_Climbing : Player
{

    [SerializeField] private float _climbSpeed = 1;

    private bool _isAtVine = false;
    private float _wallHeight = 0f;
    private float _vineRotation = 0f;

    public Action<bool> ClimbUpdated;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        _moveInputX = Input.GetAxis("Horizontal");
        _moveInputZ = Input.GetAxis("Vertical");

        if (_isAtVine && Input.GetKeyDown(KeyCode.E) && !_isCrouching)
        {
            if (_isClimbing)
            {
                _isClimbing = false;
            }
            else
            {
                StartCoroutine("StartClimbing");
                transform.rotation = Quaternion.Euler(0f, _vineRotation, 0f);
                rb.velocity *= 0;
                _isClimbing = true;
            }
        }

        if (_isClimbing)
        {
            gameObject.GetComponent<Player_Movement>().enabled = false;
            rb.useGravity = false;

            transform.position += transform.right * _moveInputX * _climbSpeed * Time.deltaTime;
            transform.position += transform.up * _moveInputZ * _climbSpeed * Time.deltaTime;
        }
        else
        {
            gameObject.GetComponent<Player_Movement>().enabled = true;
            rb.useGravity = true;
        }
    }

    IEnumerator StartClimbing()
    {
        transform.rotation = Quaternion.Euler(0f, _vineRotation, 0f);
        if (rb.velocity.y >= -0.5f)
        {
            for (int i = 0; i < 100; i++)
            {
                transform.position += transform.up * 2 * Time.deltaTime;
                yield return new WaitForSeconds(0.0005f);
            }
        }

        yield return null;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.name == "Vine")
        {
            _isAtVine = true;
            _wallHeight = collision.gameObject.transform.localScale.y;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.name == "Vine")
        {
            _isAtVine = false;
            _wallHeight = 0f;
            _isClimbing = false;
        }
    }
}