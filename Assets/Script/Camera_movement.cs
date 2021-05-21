using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_movement : MonoBehaviour
{
    public GameObject offset;
    float mouseX;
    float mouseY;

    private float rotationX = 0f;
    private float rotationY = 0f;
    [SerializeField] private float sensitivity = 2f;

    void Start()
    {

    }

    void Update()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        lockedRotation();
    }

    void lockedRotation()
    {
        rotationX += -Input.GetAxis("Mouse Y") * sensitivity;
        rotationX = Mathf.Clamp(rotationX, -20, 90);

        rotationY += -Input.GetAxis("Mouse X") * sensitivity;
        rotationY = Mathf.Clamp(rotationY, -Mathf.Infinity, Mathf.Infinity);

        offset.transform.localEulerAngles = new Vector3(rotationX, -rotationY, transform.localEulerAngles.z);

        Debug.Log(offset.transform.localEulerAngles);
    }
}