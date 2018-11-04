using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour {

    const float moveSpeedSmoothTime = .1f;
    Animator animator;
    Rigidbody playerRb;
    PlayerHealth playerHealth;
    WeaponPlayer playerWeapon;
    bool hasDied = false;

	// Use this for initialization
	void Start () {
        animator = GetComponentInChildren<Animator>();
        playerRb = GetComponent<Rigidbody>();
        playerHealth = GetComponent<PlayerHealth>();
        playerWeapon = GetComponent<WeaponPlayer>();

        Inventory.instance.onWeaponChangedCallback += OnWeaponChanged;
	}
	
	// Update is called once per frame
	void Update () {
        float xyVelocity = Vector2.SqrMagnitude(new Vector2(playerRb.velocity.x, playerRb.velocity.z));
        animator.SetFloat("velocity", xyVelocity, moveSpeedSmoothTime, Time.deltaTime);

        if(Input.GetButtonDown("Sprint"))
        {
            animator.SetBool("isSprinting", true);
        } 

        if(Input.GetButtonUp("Sprint"))
        {
            animator.SetBool("isSprinting", false);
        }

        if(Input.GetButtonDown("SwingLantern") && playerWeapon.isAltFireReady)
        {
            animator.SetTrigger("swingLantern");
        }

        if(playerHealth.GetCurrentHealth() == 0 && !hasDied)
        {
            animator.SetTrigger("hasDied");
            hasDied = true;
        }

        if(Input.GetButtonDown("Fire1") && playerWeapon.weaponItem != null && playerWeapon.isReadyToFire)
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
