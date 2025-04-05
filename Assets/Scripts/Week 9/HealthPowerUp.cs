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
    //Basically need to destrot it, but unsure how to because base should be destroying it
    //It should activate on trigger tho so idkk

    /*private new void OnTriggerEnter(Collider other)
    {
        HealthPotionUsed();
    }*/

    //decided to just leave basepowerup blank for now because idk what to do

    public void HealthPotionUsed()
    {
        PlayerRPG PlayerRPG = playerHealth.GetComponent<PlayerRPG>();

        if (PlayerRPG.currentHealth <= PlayerRPG.maxHealth)
        {
            PlayerRPG.currentHealth += amountHeal;
            PlayerRPG.currentHealth = Mathf.Clamp(PlayerRPG.currentHealth, 0, PlayerRPG.maxHealth);
            Debug.Log("You've been Healed!");
        }
    }

    protected new void OnTriggerEnter(Collider other)
    {
        other.CompareTag("Player");

        PlayerRPG player = other.GetComponent<PlayerRPG>();
        
        HealthPotionUsed();

        Destroy(this.gameObject);
        
    }
}
