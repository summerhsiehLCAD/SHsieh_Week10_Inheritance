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
        PlayerRPG PlayerRPG = playerAmmo.GetComponent<PlayerRPG>();

        if (PlayerRPG.currentAmmo <= PlayerRPG.maxAmmo)
        {
            PlayerRPG.currentAmmo += ammoPickUp;
            PlayerRPG.currentAmmo = Mathf.Clamp(PlayerRPG.currentAmmo, 0, PlayerRPG.maxAmmo);
            Debug.Log("You've picked up 5 Ammo!");
        }
    }
    private new void OnTriggerEnter(Collider other)
    {
        other.CompareTag("Player");

        PlayerRPG player = other.GetComponent<PlayerRPG>();

        AmmoPickedUp();

        Destroy(this.gameObject);

    }
}
