using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Weapon : MonoBehaviour
{
    [SerializeField]
    public WeaponItem weaponItem;

    [SerializeField]
    bool isEnemy = false;

    [SerializeField]
    public bool isReadyToFire = true;

    public float timeSinceLastFire = 0f;

    public GameObject weaponAnchor;


    // Use this for initialization
    public virtual void Start()
    {
        weaponAnchor = transform.Find("WeaponAnchor").gameObject;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (!isReadyToFire)
        {
            if (timeSinceLastFire > weaponItem.fireRate)
            {
                isReadyToFire = true;
            }
            else
            {
                timeSinceLastFire += Time.deltaTime;
            }
        }
    }

    public virtual void Fire()
    {
        if (isReadyToFire)
        {
            isReadyToFire = false;
            timeSinceLastFire = 0f;
        }
    }

    public void SetIsEnemyWeapon(bool _isEnemy)
    {
        isEnemy = _isEnemy;
    }
}

