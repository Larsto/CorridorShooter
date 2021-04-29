using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickupScript : MonoBehaviour
{
    private bool collected;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !collected)
        {
            //Give Ammo
            PlayerController.instance.activeGun.GetAmmo();
            Destroy(gameObject);

            collected = true;

            AudioManager.instace.PlaySFX(3);
        }
    }
}
