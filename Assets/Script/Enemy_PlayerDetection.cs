using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy_PlayerDetection : Enemy
{
    [SerializeField] private GameObject _player;

    private bool _playerSpotted = false;
    private bool _playerIsHidden = false;

    public Action<bool> InRangeUpdated;

    void Start()
    {
        var pHideScript = _player.GetComponent<Player_Hiding>();
        pHideScript.HiddenUpdated += pHidden;
    }

    void Update()
    {
        InRangeUpdated(_playerSpotted);

        if (_playerIsHidden)
        {
            _playerSpotted = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
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