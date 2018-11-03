using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour {


    [SerializeField]
    float movementSpeed = 5.0f;

    [SerializeField]
    float turnSpeed = 1.0f;

    [SerializeField]
    float sprintMultiplier = 2.0f;
    
    Rigidbody rb;

    float getAxisVertical;
    float getAxisHorizontal;

    // Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();	
	}
	
	// Update is called once per frame
	void Update () {
        getAxisVertical = Input.GetAxisRaw("Vertical");
        getAxisHorizontal = Input.GetAxisRaw("Horizontal");
        
        if (Input.GetButton("Sprint"))
        {
            rb.velocity = transform.forward * getAxisVertical * movementSpeed * sprintMultiplier;
        }
        else
        {
            rb.velocity = transform.forward * getAxisVertical * movementSpeed;
        }
        
        transform.Rotate(new Vector3(0, getAxisHorizontal, 0) * Time.deltaTime * turnSpeed, Space.World);
	}
}
