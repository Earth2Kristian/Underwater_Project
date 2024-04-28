using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawningItemsScript : MonoBehaviour
{
    public GameObject bombObject;
    public float spawnTime;

    void Start()
    {
        spawnTime = Random.Range(5, 10);
    }

    void Update()
    {
        spawnTime -= Time.deltaTime;

        if (spawnTime <= 0 )
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-45f, 21f), 6f, Random.Range(-38F, 28f));
            Instantiate(bombObject, randomSpawnPosition, Quaternion.identity);
            bombObject.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
            spawnTime = Random.Range(5,10);    
        }
    }
}
