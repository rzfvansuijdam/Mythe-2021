using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{

    protected float _moveInputX;
    protected float _moveInputZ;

    protected Rigidbody rb;

    protected GameObject mainCamera;

    protected static bool _isClimbing = false;
    protected static bool _isCrouching = false;
    protected static bool _isHidden = false;

    protected static int _currency = 0;

    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");

        var CrouchScript = GetComponent<Player_Crouching>();
        CrouchScript.CrouchUpdated += Crouch;

        var ClimbScript = GetComponent<Player_Climbing>();
        ClimbScript.ClimbUpdated += Climb;

        var HideScript = GetComponent<Player_Hiding>();
        HideScript.HiddenUpdated += Hide;

        var PickupScript = GetComponent<Player_Pickup>();
        PickupScript.CurrencyUpdated += addCurrency;

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
    void Hide(bool h)
    {
        _isHidden = h;
    }

    void addCurrency(int c)
    {
        _currency += c;
    }
}
