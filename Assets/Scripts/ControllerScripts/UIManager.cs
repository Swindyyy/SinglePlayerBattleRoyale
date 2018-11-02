using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIManager : MonoBehaviour {

    public static UIManager instance;

    void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
        }

        instance = this;
    }

    [SerializeField]
    Slider healthBar;

    [SerializeField]
    TextMeshProUGUI healthBarText;

    [SerializeField]
    PlayerHealth playerHealth;

    [SerializeField]
    public TextMeshProUGUI interactText;

    [SerializeField]
    public TextMeshProUGUI weaponName;

    [SerializeField]
    public Image weaponIcon;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        healthBar.value = playerHealth.GetCurrentHealth();
        healthBarText.text = playerHealth.GetCurrentHealth() + "/" + playerHealth.GetMaxHealth();
        weaponName.text = Inventory.instance.currentWeapon.name;
        weaponIcon.sprite = Inventory.instance.currentWeapon.icon;

	}
}
