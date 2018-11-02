using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipe", menuName = "Forge/Recipe")]
public class Recipe : ScriptableObject {

    public List<Ingredient> ingredientsNeededToCraft = new List<Ingredient>();

    public Ingredient craftedItem;

}
