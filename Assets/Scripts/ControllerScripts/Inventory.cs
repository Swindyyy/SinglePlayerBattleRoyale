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

    public List<Ingredient> items;
    public int itemSpace = 6;

    public List<WeaponItem> weapons;
    public int weaponSlots = 2;

    public WeaponItem currentWeapon = null;
    public WeaponItem offWeapon = null;

    int healthPotions;
    int dust;


    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public delegate void OnWeaponChanged();
    public OnWeaponChanged onWeaponChangedCallback;

    GameObject player;
    GameObject floorItem;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        WeaponItem playerWeapon = player.GetComponent<Weapon>().weaponItem;
        if (playerWeapon != null)
        {
            currentWeapon = playerWeapon;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("SwapWeapon"))
        {
            if (offWeapon != null)
            {
                SwapWeapon();
            }
        }
    }

    public bool AddItem(Ingredient item)
    {
        if (CanPickUpItem())
        {
            items.Add(item);

            if (onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke();
            }
        }

        return false;
    }

    public bool AddWeapon(WeaponItem weapon)
    {
        if (currentWeapon == null)
        {
            currentWeapon = weapon;
            EquipNewWeapon();

        } else
        {
            if (offWeapon == null)
            {
                offWeapon = weapon;
            }
            else
            {
                DropWeapon(currentWeapon);
                currentWeapon = weapon;
                EquipNewWeapon();
            }
        }

        return true;
    }

    public bool CanPickUpItem()
    {
        if (items.Count < itemSpace)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void EquipNewWeapon()
    {
        player.GetComponent<Weapon>().weaponItem = currentWeapon;

        if (onWeaponChangedCallback != null)
        {
            onWeaponChangedCallback.Invoke();
        }
    }

    public void DropItem(Ingredient itemToDrop)
    {
        itemToDrop.CreateItem(player.transform.position);
        RemoveItem(itemToDrop);
    }

    public void DropWeapon(WeaponItem weaponToDrop)
    {
        weaponToDrop.CreateItem(player.transform.position);
        GameObject.FindGameObjectWithTag(weaponToDrop.animItemTag).GetComponent<SkinnedMeshRenderer>().enabled = false;

    }

    public void RemoveItem(Ingredient itemToRemove)
    {
        items.Remove(itemToRemove);

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }

    public void RemoveWeapon(WeaponItem itemToRemove)
    {
        weapons.Remove(itemToRemove);

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }

    public void SwapWeapon()
    {
        WeaponItem temp = currentWeapon;
        currentWeapon = offWeapon;
        offWeapon = temp;
        EquipNewWeapon();
    }

    public void SetCurrentFloorItem(GameObject _floorItem)
    {
        floorItem = _floorItem;
    }

    public GameObject GetCurrentFloorItem()
    {
        return floorItem;
    }

}

