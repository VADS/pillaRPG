﻿using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public float repeatInterval;

    private void Start()
    {
        if (repeatInterval > 0)
        {
            InvokeRepeating("spawnObject", 0.0f, repeatInterval);
        }
    }

    public GameObject SpawnObject()
    {
        if (prefabToSpawn != null)
        {
            return Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
        }
        return null;
    }
}
