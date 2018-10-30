using UnityEngine;

public class Interactable : MonoBehaviour {

    public float radius = 3f;

    Transform player;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").gameObject.transform;
    }

    public virtual void Interact()
    {

    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        if(distance <= radius)
        {

        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
	
}
