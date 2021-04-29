using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healAmount;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerHealtController.instance.HealPlayer(healAmount);

            Destroy(gameObject);

            AudioManager.instace.PlaySFX(4);
        }
    }

}
