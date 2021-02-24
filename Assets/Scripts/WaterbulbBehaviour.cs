using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterbulbBehaviour : MonoBehaviour
{
    public GameObject water;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnWater", 2.0f, 3.0f);
    }

    void SpawnWater()
    {
        Vector3 waterPos = new Vector3(0.5f, -0.5f, 0f);
        Instantiate(water, waterPos, Quaternion.identity);
    }
}