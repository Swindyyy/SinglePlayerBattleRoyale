using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ForgeUIScript : MonoBehaviour
{

    #region singleton
    public static ForgeUIScript instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }

        instance = this;
    }

    #endregion

    public GameObject forgeObject;
    public GameObject forgeIngredientIconObject;
    public GameObject forgeIconTemplate;

    public Button itemToForgeButton;
    public Button forwardButton;
    public Button backButton;

    public TextMeshProUGUI itemToForgeName;
    public TextMeshProUGUI itemToForgeDescription;
    public TextMeshProUGUI itemCounter;

    public Image itemToForgeIcon;

    Recipe currentRecipe;
    List<Recipe> recipes = new List<Recipe>();
    int currentRecipeCounter = 0;

    bool canPlayerForgeItem = false;
    List<GameObject> ingredientIcons = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        recipes = ItemManager.instance.GetRecipesInGame();
    }

    void Update()
    {
        if (forgeObject.activeSelf)
        {
            if (!CheckIfIngredientsInInventory())
            {
                itemToForgeButton.interactable = false;
            } else
            {
                itemToForgeButton.interactable = true;
            }
        }
    }

    public void OnNextButtonPress()
    {
        currentRecipeCounter += 1;
        currentRecipe = recipes[currentRecipeCounter];
        backButton.interactable = true;
        itemCounter.text = currentRecipeCounter + 1 + "/" + recipes.Count;

        if (currentRecipeCounter + 1 >= recipes.Count)
        {
            forwardButton.interactable = false;
        }

        SetCurrentForgeRecipe();
    }

    public void OnPreviousButtonPress()
    {
        currentRecipeCounter -= 1;
        currentRecipe = recipes[currentRecipeCounter];
        forwardButton.interactable = true;
        itemCounter.text = currentRecipeCounter + 1 + "/" + recipes.Count;

        if (currentRecipeCounter + 1 <= 1)
        {
            backButton.interactable = false;
        }

        SetCurrentForgeRecipe();
    }

    public void OnForgeButtonPress()
    {
        CraftItem(currentRecipe.craftedItem);
        RemoveIngredients();
    }

    public void ToggleForgeUI()
    {
        if (forgeObject.activeSelf)
        {
            DisableForgeUI();
        }
        else
        {
            EnableForgeUI();
        }
    }

    public void EnableForgeUI()
    {
        forgeObject.SetActive(true);
        currentRecipeCounter = 0;
        backButton.interactable = false;
        itemCounter.text = currentRecipeCounter + 1 + "/" + recipes.Count;

        if (recipes.Count <= 1)
        {
            forwardButton.interactable = false;
        }

        currentRecipe = recipes[0];
        SetCurrentForgeRecipe();
    }

    public void DisableForgeUI()
    {
        forgeObject.SetActive(false);
    }

    public void SetCurrentForgeRecipe()
    {
        itemToForgeName.text = currentRecipe.craftedItem.name;
        itemToForgeDescription.text = currentRecipe.craftedItem.description;
        itemToForgeIcon.sprite = currentRecipe.craftedItem.icon;

        foreach (GameObject iconObject in ingredientIcons)
        {
            Destroy(iconObject);
        }

        ingredientIcons = new List<GameObject>();

        foreach (Ingredient item in currentRecipe.ingredientsNeededToCraft)
        {
            GameObject icon = Instantiate(forgeIconTemplate);
            ingredientIcons.Add(icon);
            icon.transform.SetParent(forgeIngredientIconObject.transform,false);
            icon.GetComponent<Image>().sprite = item.icon;
        }
    }

    public void CraftItem(Ingredient _item)
    {
        if (currentRecipe.craftedItem is Ingredient)
        {
            Inventory.instance.AddWeapon((WeaponItem)_item);
        }
        else
        {
            Inventory.instance.AddItem(_item);
        }
    }

    public void RemoveIngredients()
    {
        if (CheckIfIngredientsInInventory())
        {
            foreach (Ingredient ingredient in currentRecipe.ingredientsNeededToCraft)
            {
                Inventory.instance.RemoveItem(ingredient);
            }
        }
    }

    public bool CheckIfIngredientsInInventory()
    {
        bool isInInventory = true;

        foreach (Ingredient ingredient in currentRecipe.ingredientsNeededToCraft)
        {
            if (!Inventory.instance.items.Contains(ingredient))
            {
                isInInventory = false;
            }
        }

        return isInInventory;
    }
}
