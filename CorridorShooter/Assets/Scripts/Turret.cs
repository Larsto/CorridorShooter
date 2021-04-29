using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject bullet;

    public float rangeToTraget, timeBetweenShots = .5f;
    private float shotCounter;

    public Transform gun, firePoint;

    public float rotateSpeed = 45f;

    public FindClosest closest;
    // Start is called before the first frame update
    void Start()
    {
        shotCounter = timeBetweenShots;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, closest.closestEnemy.transform.position) < rangeToTraget)
        {
            gun.LookAt(closest.closestEnemy.transform.position);

            shotCounter -= Time.deltaTime;

            if(shotCounter <= 0)
            {
                Instantiate(bullet, firePoint.position, firePoint.rotation);
                shotCounter = timeBetweenShots;
            }
        } else
        {
            shotCounter = timeBetweenShots;

            gun.rotation = Quaternion.Lerp(gun.rotation, Quaternion.Euler(0f, gun.rotation.eulerAngles.y + 10, 0f), rotateSpeed * Time.deltaTime);
        }
    }
}
