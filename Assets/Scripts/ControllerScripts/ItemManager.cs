using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {

    public static ItemManager instance;

    #region singleton

    void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
        }

        instance = this;
    }

    #endregion

    [SerializeField]
    List<Item> items;

    [SerializeField]
    List<Recipe> recipes;

    float totalDropRate;
    
    // Use this for initialization
    void Start () {
        foreach (Item item in items)
        {
            totalDropRate += item.dropRate; 
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    public Item ChooseItemToDrop()
    {
        Item itemToDrop = null;

        float dropSeed = Random.Range(0, totalDropRate);
        float currentCounter = 0;

        foreach(Item item in items)
        {
            currentCounter += item.dropRate;
            if(dropSeed <=  currentCounter)
            {
                itemToDrop = item;
                break;
            }
        }

        return itemToDrop;
    }
}
