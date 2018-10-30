using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{


    bool isOccupied;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        isOccupied = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isOccupied = false;
    }

    public bool GetIsOccupied()
    {
        return isOccupied;
    }
}
