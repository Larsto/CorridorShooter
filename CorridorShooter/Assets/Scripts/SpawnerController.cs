using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public GameObject enemy;

    public float waitBetweenSpawns = 2f ,spawnTime = 2f;
    private float spawnCounter, spawnTimeCounter;
    // Start is called before the first frame update
    void Start()
    {
        spawnCounter = waitBetweenSpawns;
        spawnTimeCounter = spawnTimeCounter;
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnCounter > 0)
        {
            spawnCounter -= Time.deltaTime;
            if(spawnCounter <= 0)
            {
                Instantiate(enemy, transform.position, transform.rotation);
                spawnTimeCounter -= Time.deltaTime;
                if (spawnTimeCounter <= 0)
                {
                    spawnCounter = waitBetweenSpawns;
                    spawnTimeCounter = spawnTime;
                }
            }
        } 
    }
}
