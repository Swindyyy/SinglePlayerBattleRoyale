using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogDamageScript : MonoBehaviour {

    [SerializeField]
    Health playerHealth;

    bool isInStorm = false;

    [SerializeField]
    float tickInterval;

    float currentDuration = 0;

    [SerializeField]
    RoundManager roundManager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(currentDuration <= tickInterval)
        {
            currentDuration += Time.deltaTime;
        } else
        {
            if(isInStorm)
            {
                playerHealth.DealDamage(roundManager.GetCurrentWaveDamage());
            }

            currentDuration = 0;
        }
	}

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Fog"))
        {
            isInStorm = true;
            currentDuration = 0f;
            playerHealth.DealDamage(roundManager.GetCurrentWaveDamage());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fog"))
        {
            isInStorm = false;
        }
    }
}
