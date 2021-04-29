using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindClosest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FindClosestEnemy();
    }

    void FindClosestEnemy()
    {
        float distaceToCloasestTurret = Mathf.Infinity;
        Turret closestTurret = null;
        Turret[] allTurrets = GameObject.FindObjectsOfType<Turret>();

        foreach (Turret currentTurret in allTurrets)
        {
            float distanceToTurret = (currentTurret.transform.position - this.transform.position).sqrMagnitude;
            if(distanceToTurret < distaceToCloasestTurret)
            {
                distaceToCloasestTurret = distanceToTurret;
                closestTurret = currentTurret;
            }
        }
        Debug.DrawLine (this.transform.position, closestTurret.transform.position, Color.red);
    }
}
