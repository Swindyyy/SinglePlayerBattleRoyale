using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPlayer : Weapon
{

    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
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
                    EnemyHealth hitHealth = hit.transform.gameObject.GetComponent<EnemyHealth>();
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
