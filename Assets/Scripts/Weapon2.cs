using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;

public class Weapon2 : MonoBehaviour
{
    [SerializeField] GameObject ammo;
    [SerializeField] Transform emission;
    [SerializeField] AudioSource audioSource;

    public bool equipped = false;

    void Update()
    {
        Debug.DrawRay(emission.position, emission.forward * 10, Color.red);

        if (equipped && Input.GetMouseButtonDown(0))
        {
            if (audioSource != null) audioSource.Play();
            Instantiate(ammo, emission.position, emission.rotation);
        }
    }
}
