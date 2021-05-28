using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : Enemy
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Vector3[] _walkRoute;
    private int _walkRouteNum = 0;

    private Vector3 POI;

    private bool _playerSpotted = false;

    void Start()
    {
        var DetectionScript = GetComponent<Enemy_PlayerDetection>();
        DetectionScript.InRangeUpdated += InRange;

        POI = _walkRoute[_walkRouteNum];
    }
    
    void Update()
    {
        StartCoroutine("MoveToPOI", POI);

        Vector3 target = POI - transform.position;

        Vector3 poiDir = Vector3.RotateTowards(transform.forward, target, 5 * Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(new Vector3(poiDir.x, 0, poiDir.z));

        CheckPosition(transform.position, POI);
    }

    IEnumerator MoveToPOI(Vector3 poi)
    {
        transform.position += transform.forward * Time.deltaTime * 3f;

        yield return null;
    }

    void CheckPosition(Vector3 _ePos, Vector3 _tPos)
    {
        Vector3 _dis = _ePos - _tPos;

        if (_dis.x <= 0.5f && _dis.x >= -0.5f && _dis.z <= 0.5f && _dis.z >= -0.5f)
        {
            if (_walkRouteNum == _walkRoute.Length - 1)
            {
                _walkRouteNum = 0;
            }
            else
            {
                _walkRouteNum++;
            }
            POI = _walkRoute[_walkRouteNum];
        }
    }

    void InRange(bool i)
    {
        _playerSpotted = i;
        if (!i)
        {
            POI = _walkRoute[_walkRouteNum];
        }
        else
        {
            POI = _player.transform.localPosition;
        }
    }
}
