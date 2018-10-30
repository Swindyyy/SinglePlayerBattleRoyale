using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    [SerializeField]
    public int maxHealth = 100;

    [SerializeField]
    public int currentHealth;


	// Use this for initialization
	public virtual void Start () {
        currentHealth = maxHealth;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public virtual void DealDamage(int damage)
    {

    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public virtual void DropLoot()
    {

    }

    public virtual void Heal(int _healthToHeal)
    {

    }
}
