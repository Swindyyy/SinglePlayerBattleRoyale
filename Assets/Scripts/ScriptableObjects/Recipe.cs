using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipe", menuName = "Forge/Recipe")]
public class Recipe : ScriptableObject {

    Item firstItem;
    int firstItemAmount;

    Item secondItem;
    int secondItemAmount;

    Item craftedItem;

}
