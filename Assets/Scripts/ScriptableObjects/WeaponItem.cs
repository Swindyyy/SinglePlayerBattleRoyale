using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Inventory/Weapon")]
public class WeaponItem : Ingredient {

    [SerializeField]
    public float weaponRange = 2f;

    [SerializeField]
    public int weaponDamage = 50;

    [SerializeField]
    public float fireRate = 2.5f;

    [SerializeField]
    public float timeToFireAfterReachingTarget = 0f;

    [SerializeField]
    public bool isDefaultWeapon = true;

    public override void CreateItem(Vector3 position)
    {
        base.CreateItem(position);
    }
}
