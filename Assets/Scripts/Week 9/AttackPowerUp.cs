using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPowerUp : BasePowerUp
{

    public GameObject playerAttack;

    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {

    }



    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        player.PickUpAttackPowerUp();
    }
}
