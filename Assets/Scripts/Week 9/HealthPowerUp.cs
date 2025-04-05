using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : BasePowerUp
{
    public float amountHeal = 20;
    public GameObject playerStats;
    
    

    // Start is called before the first frame update
    void Start()
    {
        playerStats = GetComponent<PlayerRPG.Healed>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PotionUsed()
    {
       PlayerRPG currenthealth = 
    }
}
