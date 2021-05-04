using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOverwatch : MonoBehaviour
{
    public GameObject bullet;

    public float rangeToTraget, timeBetweenShots = .5f;
    private float shotCounter;

    public Transform look, firePoint;
    public FindClosest closest;
    public GameObject raycastObject;
    private bool canShoot;
    // Start is called before the first frame update
    void Start()
    {
        shotCounter = timeBetweenShots;
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    void CheckForHit()
    {
        RaycastHit objectHit;
        Vector3 fwd = raycastObject.transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(raycastObject.transform.position, fwd * rangeToTraget, Color.green);
        if (Physics.Raycast(raycastObject.transform.position, fwd, out objectHit, rangeToTraget))
        {
            if(objectHit.collider.tag == "Enemy")
            {
                canShoot = true;
            }else
            {
                canShoot = false;
            }
        }
    }

    void Shoot()
    {
        if (closest.closestEnemy != null)
        {
            if (Vector3.Distance(transform.position, closest.closestEnemy.transform.position) < rangeToTraget)
            {
                look.LookAt(closest.closestEnemy.transform.position + new Vector3(0f, -1f, 0f));

                shotCounter -= Time.deltaTime;

                if (shotCounter <= 0)
                {
                    Instantiate(bullet, firePoint.position, firePoint.rotation);
                    shotCounter = timeBetweenShots;
                }
            }
        }
    }
}
