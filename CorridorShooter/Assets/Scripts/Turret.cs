using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject bullet;

    public float rangeToTraget, timeBetweenShots = .5f;
    private float shotCounter;

    public Transform gun, firPoint;

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
        if(Vector3.Distance(transform.position, closest.closestPlayer.transform.position) < rangeToTraget)
        {
            gun.LookAt(closest.closestPlayer.transform.position + new Vector3(0f, 1.2f, 0f));

            shotCounter -= Time.deltaTime;

            if(shotCounter <= 0)
            {
                Instantiate(bullet, firPoint.position, firPoint.rotation);
                shotCounter = timeBetweenShots;
            }
        } else
        {
            shotCounter = timeBetweenShots;

            gun.rotation = Quaternion.Lerp(gun.rotation, Quaternion.Euler(0f, gun.rotation.eulerAngles.y + 10, 0f), rotateSpeed * Time.deltaTime);
        }
    }
}
