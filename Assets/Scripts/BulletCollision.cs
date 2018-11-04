using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour {

    public Transform smokePuff;
    public Transform ectoPuff;
    public int damage;


    void OnCollisionEnter(Collision coll)
    {
        ContactPoint contact = coll.contacts[0];
        Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;
        Transform particle;

        if (!coll.gameObject.CompareTag("Player"))
        {
            if (coll.gameObject.CompareTag("Enemy"))
            {
                coll.gameObject.GetComponent<EnemyHealth>().DealDamage(damage);
            }
            else
            {
                particle = Instantiate(smokePuff, pos, rotation);
                Destroy(particle.gameObject, 5f);
            }
            
            Destroy(this.gameObject);
        }
    }
}
