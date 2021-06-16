using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoader : MonoBehaviour
{

    public static Vector3 playerSpawnPos;

    void Start()
    {
        GameObject _player = (GameObject)Resources.Load("Prefabs/Player_old");

        Instantiate(_player, playerSpawnPos, Quaternion.identity);
    }
}
