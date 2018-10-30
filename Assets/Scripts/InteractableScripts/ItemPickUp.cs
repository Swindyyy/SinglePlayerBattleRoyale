using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable {

    public Item item;

    public override void Interact()
    {
        base.Interact();
        Debug.Log("Interacted");
    }

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        UIManager.instance.interactText.text = "Press F to pick up " + item.name;
        UIManager.instance.interactText.gameObject.SetActive(true);
    }

    public override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);

        UIManager.instance.interactText.gameObject.SetActive(false);
    }
}
