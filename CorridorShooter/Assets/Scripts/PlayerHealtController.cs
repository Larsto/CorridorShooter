using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealtController : MonoBehaviour
{
    //public static PlayerHealtController instance;

    public int maxHealth, currentHealth;

    public float invincibleLength = 1f;
    private float invincCounter;

    private void Awake()
    {
       // instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        UIController.instance.healthSlider.maxValue = maxHealth;
        UIController.instance.healthSlider.value = currentHealth;
        UIController.instance.healtText.text = "HEALTH: " + currentHealth + "/" + maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(invincCounter > 0)
        {
            invincCounter -= Time.deltaTime;
        }
    }

    public void DamagePlayer(int damageAmount)
    {
        if(invincCounter <= 0)
        {
            Debug.Log(damageAmount);
            currentHealth -= damageAmount;

            UIController.instance.ShowDamage();

            if (currentHealth <= 0)
            {
                gameObject.SetActive(false);

                currentHealth = 0;

                //GameManager.instance.PlayerDied();

                AudioManager.instace.StopBGM();

                AudioManager.instace.PlaySFX(5);
                AudioManager.instace.StopSFX(0);
            }
            AudioManager.instace.PlaySFX(0);
            invincCounter = invincibleLength;

            UIController.instance.healthSlider.value = currentHealth;
            UIController.instance.healtText.text = "HEALTH: " + currentHealth + "/" + maxHealth;
        }
    }

    public void HealPlayer(int healAmount)
    {
        currentHealth += healAmount;

        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        UIController.instance.healthSlider.value = currentHealth;
        UIController.instance.healtText.text = "HEALTH: " + currentHealth + "/" + maxHealth;
    }
}
