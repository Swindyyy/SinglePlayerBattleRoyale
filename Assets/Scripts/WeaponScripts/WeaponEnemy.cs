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
            if (!weaponItem.isRangedWeapon)
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
            else
            {
                GameObject projectile = Instantiate(weaponItem.projectileObject, weaponAnchor.transform.position, Quaternion.identity);
                projectile.GetComponent<Rigidbody>().AddForce(transform.forward * weaponItem.projectileSpawnSpeed);
                BulletCollision bc = projectile.GetComponent<BulletCollision>();

                if (bc != null)
                {
                    bc.damage = weaponItem.weaponDamage;
                    bc.isPlayer = false;
                }
                else
                {
                    GrenadeTimer gt = projectile.GetComponent<GrenadeTimer>();
                    gt.damage = weaponItem.weaponDamage;
                }
            }
        }

        base.Fire();
    }
}
