using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void OnTriggerEnter(Collider other)
    {
        other.CompareTag("Player");

        PlayerRPG player = other.GetComponent<PlayerRPG>();

        if (player.powerPickedUp == false)
        {
            player.powerPickedUp = true;
            Destroy(this.gameObject);
        }
    }
}
