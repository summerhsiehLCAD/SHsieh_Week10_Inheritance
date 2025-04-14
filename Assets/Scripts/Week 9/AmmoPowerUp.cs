using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPower : BasePowerUp
{
   //protected new PlayerRPG player;

    public int ammoPickUp = 5;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AmmoPickedUp()
    {

     if (player.currentAmmo <= player.maxAmmo)
        {
           player.currentAmmo += ammoPickUp;
           player.currentAmmo = Mathf.Clamp(player.currentAmmo, 0, player.maxAmmo);
            Debug.Log("You've picked up 5 Ammo!");
        }
    }
    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        AmmoPickedUp();

    }
}
