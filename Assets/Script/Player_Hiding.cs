using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player_Hiding : Player
{

    private bool _isAtBush = false;
    private bool _inEnemyRange = false;

    public Action<bool> HiddenUpdated;
    public Action<bool> SpottedUpdated;

    void Start()
    {
        
    }

    void Update()
    {
        HiddenUpdated(_isHidden);
        SpottedUpdated(_isSpotted);

        if (_isAtBush && _isCrouching)
        {
            _isHidden = true;
        }
        else
        {
            _isHidden = false;
        }

        if (_inEnemyRange && _isHidden)
        {
            _isSpotted = false;
        }else if (_inEnemyRange)
        {
            _isSpotted = true;
        }else
        {
            _isSpotted = false;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.name == "Bush")
        {
            _isAtBush = true;
            foreach (SpriteRenderer i in collision.GetComponentsInChildren<SpriteRenderer>())
            {
                Color bushColor = i.color;
                bushColor.a = 0.5f;
                i.color = bushColor;
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.name == "Bush")
        {
            _isAtBush = false;
            foreach (SpriteRenderer i in collision.GetComponentsInChildren<SpriteRenderer>())
            {
                Color bushColor = i.color;
                bushColor.a = 1f;
                i.color = bushColor;
            }
        }
    }
}
