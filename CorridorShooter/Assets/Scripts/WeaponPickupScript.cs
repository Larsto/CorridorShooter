using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickupScript : MonoBehaviour
{
    public string theGun;
    private bool collected;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !collected)
        {
            //Give Ammo
            //PlayerController.instance.AddGun(theGun);
            other.gameObject.GetComponent<PlayerController>().AddGun(theGun);
            Destroy(gameObject);

            collected = true;
            AudioManager.instace.PlaySFX(1);
        }
    }
}
