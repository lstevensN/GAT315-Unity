using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hooray : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        audioSource.Play();
    }
}
