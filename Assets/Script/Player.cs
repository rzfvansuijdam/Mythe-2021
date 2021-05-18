﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{

    protected float _moveInputX;
    protected float _moveInputZ;

    protected Rigidbody rb;

    [SerializeField] protected GameObject mainCamera;

    protected static bool _isClimbing = false;
    protected static bool _isCrouching = false;
    protected static bool _isHidden = false;

    void Start()
    {
        var CrouchScript = GetComponent<Player_Crouching>();
        CrouchScript.CrouchUpdated += Crouch;

        var ClimbScript = GetComponent<Player_Climbing>();
        ClimbScript.ClimbUpdated += Climb;

        var HideScript = GetComponent<Player_Hiding>();
        HideScript.HiddenUpdated += Hide;

        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {

    }

    void Crouch(bool c)
    {
        _isCrouching = c;
    }
    void Climb(bool c)
    {
        _isClimbing = c;
    }
    void Hide(bool c)
    {
        _isHidden = c;
    }
}
