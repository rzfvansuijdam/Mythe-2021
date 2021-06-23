using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Teleport : Player
{

    public static Dictionary<string, Vector3> TpSpots = new Dictionary<string, Vector3>
    {
        {"Castle_Front", new Vector3(-0.9f, -0.68f, 0.781f)},
        {"Castle_Outside", new Vector3(-1.14f, 36.19f, -14.45f)}
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
            if (collision.gameObject.name == "Castle_Outside")
            {
                SceneManager.LoadScene("Main", LoadSceneMode.Single);
               
            }
            else
            {
                PlayerLoader.playerSpawnPos = TpSpots[collision.gameObject.name];
                SceneManager.LoadScene("Castle_Inside", LoadSceneMode.Single);
            }
        }
    }
}
