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
            Interactable interact = itemToDropGameObject.AddComponent(typeof(Interactable)) as Interactable;
            itemToDropGameObject.GetComponent<MeshFilter>().mesh = lootToDrop.objectMesh;
            interactionCollider.radius = interact.radius;
            interactionCollider.isTrigger = true;
            
        }
    }
}
