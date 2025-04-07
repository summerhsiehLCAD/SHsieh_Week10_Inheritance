using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : PlayerRPG
{
    public GameObject bulletPrefab;

    public float bulletPower = 1000f;

    public Transform bulletSpawnPosition;

    public bool hasAmmo = true;

    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) && (currentAmmo > 0))
        {
            hasAmmo = true;

            if (hasAmmo == true)
            {
                GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPosition.position, bulletSpawnPosition.rotation);

                bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * bulletPower);

                currentAmmo--;
            }
        }
        else if (Input.GetKeyDown(KeyCode.B) && (currentAmmo <= 0))
        {
            hasAmmo = false;

            Debug.Log("Out of Ammo");
        }
    }
}
