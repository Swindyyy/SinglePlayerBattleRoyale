using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPlayer : Weapon
{
    public Transform ectoPlasmaSpurt;
    public float knockBackStrength = 5f;
    public float knockBackRange = 5f;
    public float knockBackDamage = 5f;
    public float knockBackCooldown = 3f;
    public float knockBackAnimCooldown = 0.5f;

    public bool isAltFireReady = true;
    float timeSinceLastAltFire = 0f;

    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        if (Input.GetButtonDown("Fire1") && weaponItem != null)
        {
            Invoke("Fire", weaponItem.animationDelay);
        }

        if (!isAltFireReady)
        {
            if (timeSinceLastAltFire > knockBackCooldown)
            {
                isAltFireReady = true;
            }
            else
            {
                timeSinceLastAltFire += Time.deltaTime;
            }
        }

        if (Input.GetButtonDown("SwingLantern"))
        {
            Invoke("AltFire", knockBackAnimCooldown);
        }
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
                        EnemyHealth hitHealth = hit.transform.gameObject.GetComponent<EnemyHealth>();
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

                if (bc != null) {
                    bc.damage = weaponItem.weaponDamage;
                }else
                {
                    GrenadeTimer gt = projectile.GetComponent<GrenadeTimer>();
                    gt.damage = weaponItem.weaponDamage;
                }
            }
        }

        base.Fire();
    }

    void AltFire()
    {
        if (isAltFireReady)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {

                Vector2 playerXz = new Vector2(transform.position.x, transform.position.z);
                Vector2 enemyXz = new Vector2(enemy.transform.position.x, enemy.transform.position.z);

                float distanceToPlayer = Mathf.Abs(Vector2.Distance(playerXz, enemyXz));
                Debug.Log("Distance to player: " + distanceToPlayer);
                if (distanceToPlayer <= knockBackRange)
                {
                    Vector2 forceDir = -(playerXz - enemyXz).normalized;
                    Vector3 forceDirVector3 = new Vector3(forceDir.x, 0, forceDir.y);
                    enemy.GetComponent<Rigidbody>().AddForce(forceDirVector3 * knockBackStrength);
                }
            }

            isAltFireReady = false;
            timeSinceLastAltFire = 0f;
        }
    }
}
