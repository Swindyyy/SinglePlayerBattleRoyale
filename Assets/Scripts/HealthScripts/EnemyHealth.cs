using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health {


    public Item lootToDrop;


	// Use this for initialization
	public override void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void DealDamage(int _damage)
    {
        base.DealDamage(_damage);

        currentHealth -= _damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            DropLoot();
            Destroy(gameObject);
        }
    }

    public override void DropLoot()
    {
        base.DropLoot();
        if (lootToDrop != null)
        {
            Debug.Log("Dropping " + lootToDrop.name);
            GameObject itemToDropGameObject = new GameObject(lootToDrop.name);
            itemToDropGameObject.transform.position = transform.position;
            itemToDropGameObject.AddComponent(typeof(MeshFilter));
            itemToDropGameObject.AddComponent(typeof(MeshRenderer));
            SphereCollider interactionCollider = itemToDropGameObject.AddComponent(typeof(SphereCollider)) as SphereCollider;
            if (lootToDrop is WeaponItem)
            {
                WeaponPickUp weaponInteract = itemToDropGameObject.AddComponent(typeof(WeaponPickUp)) as WeaponPickUp;
                weaponInteract.item = (WeaponItem)lootToDrop;
                interactionCollider.radius = lootToDrop.interactRadius;
            }
            else {
                ItemPickup itemPickUp = itemToDropGameObject.AddComponent(typeof(ItemPickup)) as ItemPickup;
                itemPickUp.item = lootToDrop;
                interactionCollider.radius = lootToDrop.interactRadius;
            }
            
            itemToDropGameObject.GetComponent<MeshFilter>().mesh = lootToDrop.objectMesh;
            interactionCollider.isTrigger = true;
            
        }
    }
}
