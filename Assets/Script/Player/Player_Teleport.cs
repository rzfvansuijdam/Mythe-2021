using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Teleport : Player
{

    public static Dictionary<string, Vector3> TpSpots = new Dictionary<string, Vector3>
    {
        {"Castle_Front", new Vector3(0, 2, -9)},
        {"Castle_Left", new Vector3(0, 0, 0)},
        {"Castle_Right", new Vector3(0, 0, 0)}
    };

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Teleporter")
        {
            PlayerLoader.playerSpawnPos = TpSpots[collision.gameObject.name];
            SceneManager.LoadScene("Castle_Inside", LoadSceneMode.Single);
        }
    }
}
