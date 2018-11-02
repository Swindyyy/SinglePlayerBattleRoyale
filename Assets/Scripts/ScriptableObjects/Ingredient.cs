﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ingredient", menuName = "Inventory/Ingredient")]
public class Ingredient : ScriptableObject {

    new public string name = "New Item";
    public Sprite icon;
    public GameObject objectPrefab;
    public float dropRate = 5f;
    public float interactRadius = 1f;

    public GameObject itemObject;

    public string description = "Description";

    public virtual void CreateItem(Vector3 position)
    {
        itemObject = Instantiate(objectPrefab, position, Quaternion.identity);
        itemObject.name = name;
        CapsuleCollider interactionCollider = itemObject.GetComponent <CapsuleCollider>();
        interactionCollider.radius = interactRadius;     
    }

    public virtual bool UseItem()
    {
        return false;
    }
}
