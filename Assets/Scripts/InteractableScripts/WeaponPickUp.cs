﻿using System.Collections;
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
        Debug.Log("Interacted");
    }

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        UIManager.instance.interactText.text = "Press F to equip " + item.name;
        UIManager.instance.interactText.gameObject.SetActive(true);
    }

    public override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);

        UIManager.instance.interactText.gameObject.SetActive(false);
    }
}
