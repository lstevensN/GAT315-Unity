using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject ammoPrefab;
    [SerializeField] GameObject strongAmmoPrefab;
    [SerializeField] GameObject fastAmmoPrefab;
    [SerializeField] float strongAmmoCooldown = 3;
    [SerializeField] Transform emission;
    [SerializeField] TMP_Text weaponTypeDisplay;
    [SerializeField] TMP_Text ammoCountDisplay;

    [Header("Audio")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip ammoSound;
    [SerializeField] AudioClip strongAmmoSound;
    [SerializeField] AudioClip noAmmoSound;

    float ammoType = 0;
    float strongAmmoTimer = 0;
    int ammoCount = 100;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (ammoType == 0 && ammoCount > 0)
            {
                Instantiate(ammoPrefab, emission.position, emission.rotation);
                ammoCount--;

                audioSource.clip = ammoSound;
            }
            else if (ammoType == 1 && ammoCount > 9 && strongAmmoTimer <= 0) 
            { 
                Instantiate(strongAmmoPrefab, emission.position, emission.rotation); 
                strongAmmoTimer = strongAmmoCooldown;
                ammoCount -= 10;

                audioSource.clip = strongAmmoSound;
            }
            else
            {
                audioSource.clip = noAmmoSound;
            }

            ammoCountDisplay.text = ammoCount.ToString();
            audioSource.Play();
        }

        if (Input.GetMouseButtonDown(1)) 
        {
            if (ammoType == 0)
            {
                ammoType = 1;
                weaponTypeDisplay.text = "Weapon Type: Big";
            }
            else if (ammoType == 1)
            {
                ammoType = 0;
                weaponTypeDisplay.text = "Weapon Type: Small";
            }
        }

        if (strongAmmoTimer > 0) { strongAmmoTimer -= Time.deltaTime; }
    }
}
