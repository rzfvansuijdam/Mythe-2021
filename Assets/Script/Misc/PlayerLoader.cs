using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoader : MonoBehaviour
{

    public static Vector3 playerSpawnPos = new Vector3(-6.58f, 24.34f, 70f);

    // Start is called before the first frame update
    void Start()
    {
        GameObject _player = (GameObject)Resources.Load("Prefabs/Player");

        Instantiate(_player, playerSpawnPos, Quaternion.identity);
       
    }

}
