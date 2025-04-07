using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPowerUp : BasePowerUp
{
    public float buffDuration = 15f;
    public float maxBuffDuration = 0f;

    public float buffAmount = 3f;

    public bool buffActivated = false;

    public GameObject playerAttack;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
  
    }

    public void AttackBuffActivated()
    {
        PlayerRPG PlayerRPG = playerAttack.GetComponent<PlayerRPG>();

        PlayerRPG.attackDamage += buffAmount;
        Debug.Log("Attack Buff Accquired!");


    }

    protected new void OnTriggerEnter(Collider other)
    {
        other.CompareTag("Player");

        PlayerRPG player = other.GetComponent<PlayerRPG>();

        AttackBuffActivated();

        Destroy(this.gameObject);
    }

    IEnumerator attackBuffTimer()
    {
        yield return new WaitForSeconds(buffDuration);
        AttackBuffActivated();
    }
}
