﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoader : MonoBehaviour
{

    public static Vector3 playerSpawnPos;

    // Start is called before the first frame update
    void Start()
    {
        GameObject _player = (GameObject)Resources.Load("Prefabs/Player_old");

        Instantiate(_player, playerSpawnPos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
