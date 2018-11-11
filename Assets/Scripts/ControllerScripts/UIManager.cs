using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


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

    [SerializeField]
    public GameObject pauseScreen;

    [SerializeField]
    public GameObject deathScreen;

    [SerializeField]
    public GameObject endGameScreen;

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

        if(Input.GetButtonDown("Cancel"))
        {
            TogglePause();            
        }     
       
        endGameScreen.SetActive(RoundManager.instance.IsGameOver());

        if(playerHealth.currentHealth == 0)
        {
            deathScreen.SetActive(true);
            Time.timeScale = 0f;
        }
	}

    public void TogglePause()
    {
        pauseScreen.SetActive(!pauseScreen.activeSelf);

        if (pauseScreen.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
