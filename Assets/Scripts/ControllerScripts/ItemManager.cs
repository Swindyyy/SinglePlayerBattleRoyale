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

        foreach (Ingredient item in items)
        {
            totalDropRate += item.dropRate;
        }
    }

    #endregion

    [SerializeField]
    public List<Ingredient> items;

    [SerializeField]
    List<Recipe> recipes;

    [SerializeField]
    float totalDropRate;
    
    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
		
	}

    public Ingredient ChooseItemToDrop()
    {
        Ingredient itemToDrop = null;

        float dropSeed = Random.Range(0, totalDropRate);
        float currentCounter = 0;

       
        foreach(Ingredient item in items)
        {
            currentCounter += item.dropRate;
            if(dropSeed <= currentCounter)
            {
                itemToDrop = item;
                break;
            }
        }
        
        return itemToDrop;
    }

    public List<Recipe> GetRecipesInGame()
    {
        return recipes;
    }

}
