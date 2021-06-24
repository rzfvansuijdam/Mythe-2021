using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoader : MonoBehaviour
{

    public static Vector3 playerSpawnPos = new Vector3(-2.95f, 29.83f, 37.46f);

    // Start is called before the first frame update
    void Start()
    {
        GameObject _player = (GameObject)Resources.Load("Prefabs/Player");
        Instantiate(_player, playerSpawnPos, Quaternion.identity);
    }

}
