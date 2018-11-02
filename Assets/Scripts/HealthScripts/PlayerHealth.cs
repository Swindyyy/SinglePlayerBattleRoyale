using UnityEngine;

public class PlayerHealth : Health {

    public override void Start()
    {
        base.Start();
    }


    public override void DealDamage(int _damage)
    {
        base.DealDamage(_damage);
        currentHealth -= _damage;

        if(currentHealth <= 0)
        {
            currentHealth = 0;
        }
    }

    public override void Heal(int _healthToHeal)
    {
        base.Heal(_healthToHeal);

        currentHealth += _healthToHeal;

        if(currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    /* 
 * Returns true if heal was able to occur.
 * Returns false if already at max health
 */
    public bool CanPlayerHeal()
    {
        if (currentHealth == maxHealth)
        {
            return false;
        }
        else {
            return true;
        }
    }
}
