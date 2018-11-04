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

    Color transparent;
    Color opaque;

    // Use this for initialization
    void Start () {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        transparent = Color.white;
        transparent.a = 0;
        opaque = Color.white;
        opaque.a = 1;
	}
	
	// Update is called once per frame
	void Update () {
        healthBar.value = playerHealth.GetCurrentHealth();
        healthBarText.text = playerHealth.GetCurrentHealth() + "/" + playerHealth.GetMaxHealth();
        if (Inventory.instance.currentWeapon != null)
        {
            weaponName.text = Inventory.instance.currentWeapon.name;
            weaponIcon.sprite = Inventory.instance.currentWeapon.icon;
            weaponIcon.color = opaque;
        }
        else
        {
            weaponName.text = "No weapon equipped!";
            weaponIcon.sprite = null;
            weaponIcon.color = transparent;
        }

	}
}
