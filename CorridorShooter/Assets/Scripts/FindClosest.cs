using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindClosest : MonoBehaviour
{
    public bool findPlayer;
    public bool findEnemy;

    [HideInInspector]
    public PlayerHealtController closestPlayer = null;
    [HideInInspector] 
    public EnemyController closestEnemy = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (findPlayer)
        {
            FindClosestPlayer();
        }
        if(findEnemy)
        {
            FindClosestEnemy();
        }
       
        
    }

    void FindClosestEnemy()
    {
        float distaceToCloasestEnemy = Mathf.Infinity;
        EnemyController[] allEnemys = GameObject.FindObjectsOfType<EnemyController>();

        foreach (EnemyController currentEnemy in allEnemys)
        {
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if(distanceToEnemy < distaceToCloasestEnemy)
            {
                distaceToCloasestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;
            }
        }
        Debug.DrawLine (this.transform.position, closestEnemy.transform.position, Color.red);
    }

    void FindClosestPlayer()
    {
        float distaceToCloasestEnemy = Mathf.Infinity;
        PlayerHealtController[] allPlayers = GameObject.FindObjectsOfType<PlayerHealtController>();

        foreach (PlayerHealtController currentPlayer in allPlayers)
        {
            float distanceToPlayer = (currentPlayer.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToPlayer < distaceToCloasestEnemy)
            {
                distaceToCloasestEnemy = distanceToPlayer;
                closestPlayer = currentPlayer;
            }
        }
        Debug.DrawLine(this.transform.position, closestPlayer.transform.position, Color.blue);
    }
}
