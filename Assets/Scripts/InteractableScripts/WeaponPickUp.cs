using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : Interactable {

    public WeaponItem item;

    // Use this for initialization
    public override void Start()
    {
        base.Start();
    }

    public override void Interact()
    {
        base.Interact();


            EquipWeapon();
            Destroy(this.gameObject);
            UIManager.instance.interactText.gameObject.SetActive(false);

    }

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        if (other.CompareTag("Player"))
        {
            UIManager.instance.interactText.text = "Press F to equip " + item.name;
            UIManager.instance.interactText.gameObject.SetActive(true);
        }
    }

    public override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);

        if (other.CompareTag("Player"))
        {
            UIManager.instance.interactText.gameObject.SetActive(false);
            Inventory.instance.SetCurrentFloorItem(null);
        }
    }

    void EquipWeapon()
    {
        Inventory.instance.AddWeapon(item);
    }
}
