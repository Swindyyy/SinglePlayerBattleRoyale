using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject {

    new public string name = "New Item";
    public Sprite icon;
    public Mesh objectMesh;
    public float dropRate = 5f;
    public float interactRadius = 1f;
}
