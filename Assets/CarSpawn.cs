using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawn : MonoBehaviour
{
    [SerializeField] GameObject car;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(car, transform.position + new Vector3(Random.Range(-25, 25), 0, Random.Range(-25, 25)), Quaternion.identity);
        }
    }
}
