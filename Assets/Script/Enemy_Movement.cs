using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : Enemy
{

    private Vector3 POI;

    void Start()
    {
        POI = new Vector3(Random.Range(-5, 5), transform.position.y, Random.Range(-5, 5));
    }
    
    void Update()
    {
        if (!_playerSpotted)
        {
            StartCoroutine("MoveToPOI");
        }
    }

    IEnumerator MoveToPOI()
    {
        Vector3 eRot = transform.localEulerAngles;

        transform.position += transform.forward * Time.deltaTime * 3.5f;

        eRot.y += 1f;
        transform.rotation = Quaternion.Euler(eRot.x, eRot.y, eRot.z);
        yield return null;
    }
}
