using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerAnimator : MonoBehaviour {

    const float moveSpeedSmoothTime = .1f;
    Animator animator;
    Rigidbody playerRb;
    PlayerHealth playerHealth;
    WeaponPlayer playerWeapon;
    bool hasDied = false;
    AudioSource footsteps;

    [SerializeField]
    AudioClip footstepSlow;

    [SerializeField]
    AudioClip footstepsFast;

	// Use this for initialization
	void Start () {
        animator = GetComponentInChildren<Animator>();
        playerRb = GetComponent<Rigidbody>();
        playerHealth = GetComponent<PlayerHealth>();
        playerWeapon = GetComponent<WeaponPlayer>();

        Inventory.instance.onWeaponChangedCallback += OnWeaponChanged;
        footsteps = GetComponent<AudioSource>();        
	}
	
	// Update is called once per frame
	void Update () {
        float xyVelocity = Vector2.SqrMagnitude(new Vector2(playerRb.velocity.x, playerRb.velocity.z));
        animator.SetFloat("velocity", xyVelocity, moveSpeedSmoothTime, Time.deltaTime);

        if (xyVelocity == 0)
        {
            footsteps.mute = true;
        }
        else
        {
            footsteps.mute = false;
        }

        if(Input.GetButtonDown("Sprint"))
        {
            animator.SetBool("isSprinting", true);
            if(footstepsFast != null)
            {
                footsteps.clip = footstepsFast;
                footsteps.Play();
            }
        } 

        if(Input.GetButtonUp("Sprint"))
        {
            animator.SetBool("isSprinting", false);
            if(footstepSlow != null)
            {
                footsteps.clip = footstepSlow;
                footsteps.Play();
            }
        }

        if(Input.GetButtonDown("SwingLantern") && playerWeapon.isAltFireReady && !EventSystem.current.IsPointerOverGameObject())
        {
            animator.SetTrigger("swingLantern");
        }

        if(playerHealth.GetCurrentHealth() == 0 && !hasDied)
        {
            animator.SetTrigger("hasDied");
            hasDied = true;
        }

        if(Input.GetButtonDown("Fire1") && playerWeapon.weaponItem != null && playerWeapon.isReadyToFire && !EventSystem.current.IsPointerOverGameObject())
        {
            animator.SetTrigger("fireWeapon");
        }

	}

    void OnWeaponChanged()
    {
        WeaponItem currentWep = Inventory.instance.currentWeapon;
        WeaponItem offWep = Inventory.instance.offWeapon;

        if (currentWep != null)
        {
            GameObject.FindGameObjectWithTag(currentWep.animItemTag).GetComponent<SkinnedMeshRenderer>().enabled = true;
            animator.SetLayerWeight(currentWep.animLayerIndex, 1.0f);
        }

        if (offWep != null)
        {
            GameObject.FindGameObjectWithTag(offWep.animItemTag).GetComponent<SkinnedMeshRenderer>().enabled = false;
            animator.SetLayerWeight(offWep.animLayerIndex, 0.0f);
        }
    }
}
