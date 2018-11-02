using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {

    public Image icon;
    public Button removeButton;
    Ingredient item;


    public void AddItem(Ingredient newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;

    }

    public void OnRemoveButton()
    {
        Inventory.instance.DropItem(item);
    }

    public void OnItemClick()
    {
        bool didUseItem = item.UseItem();
        if (didUseItem)
        {
            Inventory.instance.RemoveItem(item);
        }
    }
}
