using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    protected static bool _playerIsHidden = false;
    protected static bool _playerSpotted = false;

    void Start()
    {

    }
    
    void Update()
    {
        Debug.Log("Spotted: " + _playerSpotted + ", Hidden: " + _playerIsHidden);
    }

    public void SetSpotted(bool newValue)
    {
        _playerSpotted = newValue;
    }
}
