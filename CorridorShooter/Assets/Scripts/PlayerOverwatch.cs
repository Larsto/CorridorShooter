using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOverwatch : MonoBehaviour
{
    public GameObject bullet;

    public float rangeToTraget, timeBetweenShots = .5f;
    private float shotCounter;

    public Transform gun, firePoint;

    public FindClosest closest;
    // Start is called before the first frame update
    void Start()
    {
        shotCounter = timeBetweenShots;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, closest.closestEnemy.transform.position) < rangeToTraget)
        {
            gun.LookAt(closest.closestEnemy.transform.position);

            shotCounter -= Time.deltaTime;

            if (shotCounter <= 0)
            {
                Instantiate(bullet, firePoint.position, firePoint.rotation);
                shotCounter = timeBetweenShots;
            }
        }
    }
}
