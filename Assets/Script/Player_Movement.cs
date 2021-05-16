using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : Player
{
    [SerializeField] private float _maxSpeed = 7;
    [SerializeField] private float _accelSpeed = 20;

    private float _moveInputX;
    private float _moveInputZ;

    private bool isSprinting = false;

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

        if (vel.z >= _maxSpeed || vel.z <= -_maxSpeed)
        {
            rb.velocity = new Vector3(vel.x, vel.y, _maxSpeed * _movement.z);
        }
        if (vel.x >= _maxSpeed || vel.x <= -_maxSpeed)
        {
            rb.velocity = new Vector3(_maxSpeed * _movement.x, vel.y, vel.z);
        }

        rb.velocity += new Vector3(_movement.x, 0, _movement.z) * _accelSpeed * Time.deltaTime;
    }
}
