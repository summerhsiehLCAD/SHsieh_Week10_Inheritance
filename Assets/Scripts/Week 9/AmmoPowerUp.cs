using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPower : BasePowerUp
{
    public GameObject playerAmmo;
    public int ammoPickUp = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AmmoPickedUp()
    {
        Shooter Shooter = playerAmmo.GetComponent<Shooter>();

        if (Shooter.currentAmmo <= Shooter.maxAmmo)
        {
            Shooter.currentAmmo += ammoPickUp;
            Shooter.currentAmmo = Mathf.Clamp(Shooter.currentAmmo, 0, Shooter.maxAmmo);
            Debug.Log("You've picked up 5 Ammo!");
        }
    }
    protected new void OnTriggerEnter(Collider other)
    {
        other.CompareTag("Player");

        PlayerRPG player = other.GetComponent<PlayerRPG>();

        AmmoPickedUp();

        Destroy(this.gameObject);

    }
}
