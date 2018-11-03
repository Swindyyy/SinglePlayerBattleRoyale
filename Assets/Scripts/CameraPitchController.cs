using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPitchController : MonoBehaviour {

    public static float CAM_ANGLE_MAX = 50f;
    public static float CAM_ANGLE_MIN = 15f;

    public Transform camTransform;
    public Transform lookAt;
    public Camera cam;

    private float sensitivityY = 25f;
    private float yInput = 0f;
    private GameObject player;

	// Use this for initialization
	void Start () {
        camTransform = transform;
        cam = Camera.main;
        lookAt = GameObject.FindGameObjectWithTag("CameraAnchor").transform;
        player = GameObject.FindGameObjectWithTag("Player");
        
	}
	
	// Update is called once per frame
	void Update () {
        yInput = -Input.GetAxis("Mouse ScrollWheel") * sensitivityY;
	}

    void LateUpdate()
    {
        Vector3 currentLookAtRot = lookAt.localRotation.eulerAngles;
        currentLookAtRot.x += yInput;
        currentLookAtRot.x = Mathf.Clamp(currentLookAtRot.x, CAM_ANGLE_MIN, CAM_ANGLE_MAX);
        lookAt.localRotation = Quaternion.Euler(currentLookAtRot);
    }
}
