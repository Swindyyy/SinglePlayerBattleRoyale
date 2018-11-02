using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health {


    public Ingredient lootToDrop;


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

            lootToDrop.CreateItem(transform.position);           
        }
    }
}
