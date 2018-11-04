using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeTimer : MonoBehaviour {

    public Transform particleEffects;
    public float fuseTime = 2.5f;
    public int damage;

    List<GameObject> targets = new List<GameObject>();

    void Start()
    {
        Invoke("Explode", fuseTime);
    }

    void Explode()
    {
        GameObject particles = Instantiate(particleEffects, transform.position, Quaternion.identity).gameObject;
        Destroy(particles, 5f);

        foreach(GameObject target in targets)
        {
            if(target.CompareTag("Enemy"))
            {
                target.GetComponent<EnemyHealth>().DealDamage(damage);
            }
        }


        Destroy(this.gameObject);
    }

    void OnTriggerEnter(Collider coll)
    {
        targets.Add(coll.gameObject);
    }

    void OnTriggerExit(Collider coll)
    {
        targets.Remove(coll.gameObject);
    }

	
}
