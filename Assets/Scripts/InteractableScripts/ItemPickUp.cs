using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable {

    public Ingredient item;

    public override void Interact()
    {
        base.Interact();        

        if (Inventory.instance.CanPickUpItem())
        {
            Inventory.instance.AddItem(item);
            Destroy(this.gameObject);
            UIManager.instance.interactText.gameObject.SetActive(false);
        }
    }

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        if (other.CompareTag("Player"))
        {
            UIManager.instance.interactText.text = "Press F to pick up " + item.name;
            UIManager.instance.interactText.gameObject.SetActive(true);
        }
    }

    public override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
        if (other.CompareTag("Player"))
        {
            UIManager.instance.interactText.gameObject.SetActive(false);
        }
    }
}
