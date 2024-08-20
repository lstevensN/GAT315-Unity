using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Block : MonoBehaviour
{
    [SerializeField] int points = 100;
    [SerializeField] AudioSource audioSource;
    [SerializeField] TMP_Text score;

    Rigidbody rb;
    bool destroyed = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (rb.velocity.magnitude > 2 || rb.angularVelocity.magnitude > 2)
        {
            audioSource.Play();
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (!destroyed && other.CompareTag("Kill") && rb.velocity.magnitude == 0 && rb.angularVelocity.magnitude == 0)  // Checking if object has stopped moving
        {
            destroyed = true;
            // print(points);
            Destroy(gameObject, 2);

            score.text = (int.Parse(score.text) + points).ToString();
        }
    }
}
