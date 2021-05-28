using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : Player
{
    [SerializeField] private float _maxSpeed = 7;
    [SerializeField] private float _accelSpeed = 20;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        _moveInputX = Input.GetAxis("Horizontal");
        _moveInputZ = Input.GetAxis("Vertical");

        Vector3 _moveX = mainCamera.transform.right * _moveInputX;
        Vector3 _moveZ = mainCamera.transform.forward * _moveInputZ;
        Vector3 _movement = _moveX + _moveZ;

        Vector3 vel = rb.velocity;

        float mag = vel.magnitude;
        if (mag >= _maxSpeed)
        {
            vel = vel.normalized * _maxSpeed;
        }
        else
        {
            rb.velocity += new Vector3(_movement.x, 0, _movement.z) * _accelSpeed * Time.deltaTime;
        }
    }
}
