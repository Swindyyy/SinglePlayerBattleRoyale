using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBox : Interactable {

    public List<Ingredient> itemsToDrop = new List<Ingredient>();

    public int maxNumberOfItemsToDrop = 5;
    public int minNumberOfItemsToDrop = 2;

    public GameObject offsetPoint1;
    public GameObject offsetPoint2;
    Vector3 offsetDirection;


	// Use this for initialization
	public override void Start () {
        base.Start();

        if(maxNumberOfItemsToDrop > ItemManager.instance.items.Count)
        {
            maxNumberOfItemsToDrop = ItemManager.instance.items.Count;
        }

        int numItemsToDrop = Random.Range(minNumberOfItemsToDrop, maxNumberOfItemsToDrop);
        
        for (int i = 0; i < numItemsToDrop; i++)
        {
            Ingredient itemToAdd = ItemManager.instance.ChooseItemToDrop();
            itemsToDrop.Add(itemToAdd);            
        }

        offsetDirection = (offsetPoint1.transform.position - offsetPoint2.transform.position).normalized;        
	}
	
    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        if (other.CompareTag("Player") && isInteractable)
        {
            UIManager.instance.interactText.text = "Press F to open coffin";
            UIManager.instance.interactText.gameObject.SetActive(true);
        }
    }

    public override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);

        if (other.CompareTag("Player"))
        {
            UIManager.instance.interactText.gameObject.SetActive(false);
        }
    }

    public override void Interact()
    {
        base.Interact();

        if (isInteractable)
        {
            foreach (Ingredient item in itemsToDrop)
            {
                float offSet = Random.Range(-2f, 2f);
                Vector3 vectorOffset = offsetDirection * offSet;
                item.CreateItem(transform.position + vectorOffset);
            }

            isInteractable = false;
            UIManager.instance.interactText.gameObject.SetActive(false);
        }
    }
}
