using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTruckBehavior : MonoBehaviour
{
    public float chaosFactor = 5f;

    void Update()
    {
        if (Random.Range(0, 100) < 5) // 5% de probabilidad
        {
            transform.Rotate(Vector3.up * Random.Range(-chaosFactor, chaosFactor));
        }
    }
}
