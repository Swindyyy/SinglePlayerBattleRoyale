using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour {


    [SerializeField]
    float movementSpeed = 5.0f;

    [SerializeField]
    float lookSensitivity = 1.0f;

    [SerializeField]
    Camera cam;
    
    Rigidbody rb;

    float getAxisVertical;
    float getAxisHorizontal;
    float getAxisCameraX;
    float getAxisCameraY;

    Vector3 cameraRotation = Vector3.zero;
    Vector3 camOffset = Vector3.zero;

    // Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();	
        if(cam != null)
        {
            camOffset = cam.transform.localPosition;
        }
	}
	
	// Update is called once per frame
	void Update () {
        getAxisVertical = Input.GetAxisRaw("Vertical");
        getAxisHorizontal = Input.GetAxisRaw("Horizontal");
        getAxisCameraY = Input.GetAxisRaw("Mouse X");
        getAxisCameraX = Input.GetAxisRaw("Mouse Y");


	}

    void FixedUpdate()
    {
        // Apply movement

        Vector3 _verticalMovement = transform.forward * getAxisVertical;
        Vector3 _horizontalMovement = transform.right * getAxisHorizontal;
        Vector3 _finalVelocity = (_verticalMovement + _horizontalMovement).normalized * movementSpeed;

        Vector3 _lookX = new Vector3(getAxisCameraX, 0f, 0f) * lookSensitivity;
        Vector3 _lookY = new Vector3(0f, getAxisCameraY, 0f) * lookSensitivity;
        
        rb.MoveRotation(rb.rotation * Quaternion.Euler(_lookY));

        if (cam != null)
        {
            camOffset = Quaternion.AngleAxis(getAxisCameraX * lookSensitivity, Vector3.right) * camOffset;
            cam.transform.position = transform.position + camOffset;
            cam.transform.LookAt(transform.position);
        }


        if (_finalVelocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + _finalVelocity * Time.fixedDeltaTime);
        }
    }
}
