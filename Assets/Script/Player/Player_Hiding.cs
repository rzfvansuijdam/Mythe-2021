using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player_Hiding : Player
{
    private bool _isHiding = false;

    public Action<bool> HiddenUpdated;

    void Start()
    {
        
    }

    void Update()
    {
        HiddenUpdated(_isHidden);

        if (_isHiding && _isCrouching)
        {
            _isHidden = true;
        }
        else
        {
            _isHidden = false;
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.tag == "Hideable")
        {
            _isHiding = true;
            if (collision.name == "Hay")
            {
                foreach (SpriteRenderer i in collision.GetComponentsInChildren<SpriteRenderer>())
                {
                    Color bushColor = i.color;
                    bushColor.a = 0.5f;
                    i.color = bushColor;
                }
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Hideable")
        {
            _isHiding = false;
            if (collision.name == "Hay")
            {
                foreach (SpriteRenderer i in collision.GetComponentsInChildren<SpriteRenderer>())
                {
                    Color bushColor = i.color;
                    bushColor.a = 1f;
                    i.color = bushColor;
                }
            }
        }
    }
}
