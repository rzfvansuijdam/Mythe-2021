using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Climbing : Player
{

    private bool _isAtVine = false;
    private float _wallHeight = 0f;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (_isAtVine && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine("climbWall", _wallHeight);
        }
    }

    IEnumerator climbWall(float wallHeight)
    {
        wallHeight += 0.05f;
        float climbTime = wallHeight / 3;

        gameObject.GetComponent<Player_Movement>().enabled = false;
        rb.useGravity = false;

        for (int i = 0; i < 100; i++)
        {
            transform.position += new Vector3(0, wallHeight / 100, 0);
            yield return new WaitForSeconds(climbTime / 100);
        }
        for (int i = 0; i < 20; i++)
        {
            transform.position += transform.forward / 20;
            yield return new WaitForSeconds(climbTime / 100);
        }

        gameObject.GetComponent<Player_Movement>().enabled = true;
        rb.useGravity = true;

        yield return null;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.name == "Vine")
        {
            _isAtVine = true;
            _wallHeight = collision.gameObject.transform.localScale.y;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        _isAtVine = false;
        _wallHeight = 0f;
    }
}
