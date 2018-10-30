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
}
