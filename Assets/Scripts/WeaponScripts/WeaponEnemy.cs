using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEnemy : Weapon {


    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Fire()
    {
        if (isReadyToFire)
        {
            RaycastHit hit;

            if (weaponAnchor != null)
            {
                Debug.DrawRay(weaponAnchor.transform.position, weaponAnchor.transform.TransformDirection(Vector3.forward) * weaponItem.weaponRange, Color.yellow);
                if (Physics.Raycast(weaponAnchor.transform.position, weaponAnchor.transform.TransformDirection(Vector3.forward), out hit, weaponItem.weaponRange))
                {
                    //Debug.Log("Hit succesful, hit: " + hit.transform.gameObject.name);
                    PlayerHealth hitHealth = hit.transform.gameObject.GetComponent<PlayerHealth>();
                    if (hitHealth != null)
                    {
                        hitHealth.DealDamage(weaponItem.weaponDamage);
                        Debug.Log("Dealing damage to enemy");
                    }
                }
            }
        }

        base.Fire();
    }
}
