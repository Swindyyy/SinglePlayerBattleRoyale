using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forge : Interactable {

	// Use this for initialization
	public override void Start () {
        base.Start();
	}
	

    public override void Interact()
    {
        base.Interact();
        Debug.Log("Interacted");

        ForgeUIScript.instance.EnableForgeUI();
    }

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        if (other.CompareTag("Player"))
        {
            UIManager.instance.interactText.text = "Press F to use forge";
            UIManager.instance.interactText.gameObject.SetActive(true);
        }
    }

    public override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);

        if (other.CompareTag("Player"))
        {
            UIManager.instance.interactText.gameObject.SetActive(false);
            ForgeUIScript.instance.DisableForgeUI();
        }
    }
}
