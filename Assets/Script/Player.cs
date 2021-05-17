using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    protected float _moveInputX;
    protected float _moveInputZ;

    protected Rigidbody rb;

    [SerializeField] protected GameObject mainCamera;

    //protected bool isCrouching = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
