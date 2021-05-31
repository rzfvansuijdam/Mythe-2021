﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy_PlayerDetection : Enemy
{

    [SerializeField] private GameObject _player;

    private bool _playerSpotted = false;
    private bool _playerIsHidden = false;
    private bool _rayHitPlayer = false;

    public Action<bool> InRangeUpdated;

    void Start()
    {
        var pHideScript = _player.GetComponent<Player_Hiding>();
        pHideScript.HiddenUpdated += pHidden;
    }

    void Update()
    {
        InRangeUpdated(_playerSpotted);

        Vector3 rayDir = _player.transform.position - transform.position;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, rayDir, out hit))
        {
            if(hit.collider.tag == "Player")
            {
                _rayHitPlayer = true;
            }
            else
            {
                _rayHitPlayer = false;
            }
        }

        if (_playerIsHidden)
        {
            _playerSpotted = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Player" && _rayHitPlayer)
        {
            if (!_playerIsHidden)
            {
                _playerSpotted = true;
            }
            else
            {
                _playerSpotted = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            _playerSpotted = false;
        }
    }

    void pHidden(bool h)
    {
        _playerIsHidden = h;
    }
}