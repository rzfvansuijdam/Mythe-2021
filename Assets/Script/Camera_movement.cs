using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_movement : MonoBehaviour
{
    public Camera camera;
    public GameObject offset;
    float mouseX;
    float mouseY;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        offset.transform.Rotate(0, mouseX, 0);
        //camera.transform.Rotate(-mouseY, 0, 0);

        lockedRotation();
    }
    private float rotationX = 0f;
    private float rotationY = 0f;
    private float sensitivity = 2f;


    void lockedRotation()
    {
        rotationX += -Input.GetAxis("Mouse Y") * sensitivity;
        rotationX = Mathf.Clamp(rotationX, -25, 90);

        rotationY += Input.GetAxis("Mouse X") * sensitivity;
        rotationY = Mathf.Clamp(-Mathf.Infinity, rotationY, Mathf.Infinity);

        offset.transform.localEulerAngles = new Vector3(rotationX, rotationY, transform.localEulerAngles.z);

        

        
    }
}