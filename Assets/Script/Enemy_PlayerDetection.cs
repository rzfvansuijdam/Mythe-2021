using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy_PlayerDetection : Enemy
{
    [SerializeField] private GameObject _player;

    public Action<bool> PlayerSpottedUpdated;

    void Start()
    {
        var HideScript = _player.GetComponent<Player_Hiding>();
        HideScript.SpottedUpdated += PlayerSpotted;
    }
    
    void Update()
    {
        PlayerSpottedUpdated(_playerSpotted);
    }
    
    void PlayerSpotted(bool s)
    {
        _playerSpotted = s;
    }
}
