using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePowerUp : MonoBehaviour
{
    protected PlayerRPG player;
    protected float respawnDuration = 20f;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        player = FindFirstObjectByType<PlayerRPG>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
       
      //  player = other.GetComponent<PlayerRPG>();

        if (other.CompareTag("Player"))
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;

            Invoke("Respawn", respawnDuration);
        }
    }

      /*  GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        Invoke("Respawn", respawnDuration); 
    }*/

    protected void Respawn()
    {
        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<Collider>().enabled = true;
    }
}
