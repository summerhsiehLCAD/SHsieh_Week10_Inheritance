using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bulletPrefab;

    public PlayerRPG player; //references the playerRPG script

    public float bulletPower = 1000f;

    public Transform bulletSpawnPosition;

    public bool hasAmmo = true;

    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        
        //player.(componnent) will reference whatever variable is in the PlayerRPG script

       if (Input.GetKeyDown(KeyCode.B) && (player.currentAmmo > 0))
        {
            hasAmmo = true;

            if (hasAmmo == true)
            {
                GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPosition.position, bulletSpawnPosition.rotation);

                bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * bulletPower);

                player.currentAmmo--;
            }
        }
       else if (Input.GetKeyDown(KeyCode.B) && (player.currentAmmo <= 0))
        {
            hasAmmo = false;

            Debug.Log("Out of Ammo");
        }
    }
}
