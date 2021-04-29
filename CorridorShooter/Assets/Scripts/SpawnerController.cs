using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public GameObject enemy;

    public float spawnRate, waitBetweenSpawns = 2f ,spawnTime = 2f, spawnDistance = 5f;
    private float spawnCount, spawnWaitCounter, spawnTimeCounter;
    private Vector3 targetPoint;

    public FindClosest closest;
    // Start is called before the first frame update
    void Start()
    {
        spawnTimeCounter = spawnTime;
        spawnWaitCounter = waitBetweenSpawns;
    }

    // Update is called once per frame
    void Update()
    {
        targetPoint = closest.closestPlayer.transform.position;
        if (Vector3.Distance(transform.position, targetPoint) < spawnDistance)
        {
            if (spawnWaitCounter > 0)
            {
                spawnWaitCounter -= Time.deltaTime;
                if (spawnWaitCounter <= 0)
                {
                    spawnTimeCounter = spawnTime;
                }
            }
            else
            {
                spawnTimeCounter -= Time.deltaTime;
                if (spawnTimeCounter > 0)
                {
                    spawnCount -= Time.deltaTime;
                    if (spawnCount <= 0)
                    {
                        spawnCount = spawnRate;
                        Instantiate(enemy, transform.position, transform.rotation);
                    }
                }
                else
                {
                    spawnWaitCounter = waitBetweenSpawns;
                }
            }
        }
            
    }
}
