using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : BasePowerUp
{
    public float amountHeal = 25;
    public GameObject playerHealth;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HealthPotionUsed()
    {

        if (player.currentHealth <= player.maxHealth)
        {
            player.currentHealth += amountHeal;
            player.currentHealth = Mathf.Clamp(player.currentHealth, 0, player.maxHealth);
            Debug.Log("You've been Healed!");
        }
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        HealthPotionUsed();

    }
}
