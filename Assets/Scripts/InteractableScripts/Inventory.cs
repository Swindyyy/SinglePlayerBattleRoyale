using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    #region Singleton
    public static Inventory instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }

        instance = this;
    }

    #endregion

    public List<Item> items;

    public List<WeaponItem> weapons;

    int healthPotions;

    int dust;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Add(Item item)
    {

    }
}
