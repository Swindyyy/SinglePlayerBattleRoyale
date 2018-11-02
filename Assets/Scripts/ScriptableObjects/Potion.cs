using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Health Potion", menuName = "Inventory/Health Potion")]
public class Potion : Ingredient {

    public int healthToHeal;

    public override bool UseItem()
    {
        base.UseItem();
        PlayerHealth ph = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();

        if (ph.CanPlayerHeal())
        {
            ph.Heal(healthToHeal);
            return true;
        } else
        {
            return false;
        }
    }
}
