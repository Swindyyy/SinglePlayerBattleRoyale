using UnityEngine;

public class Interactable : MonoBehaviour {

    public float radius = 3f;

    public Transform player;

    public bool isInRangeOfObject = false;


    public virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").gameObject.transform;
    }

    public virtual void Interact()
    {

    }

    void Update()
    {
        if (isInRangeOfObject)
        {
            if (Input.GetButtonDown("Interact"))
            {
                Interact();
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
	
    public virtual void OnTriggerEnter(Collider other)
    {
        isInRangeOfObject = true;
    }

    public virtual void OnTriggerExit(Collider other)
    {
        isInRangeOfObject = false;
    }
}
