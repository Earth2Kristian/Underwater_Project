using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawningItemsScript : MonoBehaviour
{
    // Respawning for Bombs Variables
    public GameObject bombObject;
    public float bombSpawnTime;

    // Respawing for Oxygen Tanks Variables
    public GameObject oxygenTankObject;
    public float oxygenTankSpawnTime;

    void Start()
    {
        // Spawn Times will be set at the beginning of the gameplay
        bombSpawnTime = Random.Range(5, 10);
        oxygenTankSpawnTime = Random.Range(10, 20);
    }

    void Update()
    {
        // Bombs' Spawn Time will decrease by time
        bombSpawnTime -= Time.deltaTime;

        // Oxygen Tanks' Spawn Time will decrease by time
        oxygenTankSpawnTime -= Time.deltaTime;

        if (bombSpawnTime <= 0 )
        {
            // A bomb will spawn in the area once its spawn time has reach down to 0
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-45f, 21f), 6f, Random.Range(-38f, 28f));
            Instantiate(bombObject, randomSpawnPosition, Quaternion.identity);
            bombObject.transform.rotation = Quaternion.Euler(-180f, 90f, 0f);
            bombSpawnTime = Random.Range(5,10);    // Spawn Time will reset
        }
        if (oxygenTankSpawnTime <= 0 )
        {
            // A oxygen tank will spawn in the area once its spawn time has reach down to 0
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-45f, 21f), 6f, Random.Range(-38f, 28f));
            Instantiate(oxygenTankObject, randomSpawnPosition, Quaternion.identity);
            oxygenTankObject.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
            oxygenTankSpawnTime = Random.Range(5, 10);    // Spawn Time will reset
        }
    }
}
