using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    protected static bool _playerIsHidden = false;
    protected static bool _playerSpotted = false;

    void Start()
    {
        var DetectionScript = GetComponent<Enemy_PlayerDetection>();
        DetectionScript.PlayerSpottedUpdated += SpotPlayer;
    }
    
    void Update()
    {
        
    }

    void SpotPlayer(bool s)
    {
        _playerSpotted = s;
    }
}
