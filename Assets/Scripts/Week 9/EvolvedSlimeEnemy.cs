using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvolvedSlimeEnemy : BaseEnemy
{
    public AudioSource attackEv;
    public AudioSource damageEv;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        Debug.Log("HeeHo I'm a bigger slime!");
    }

    // Update is called once per frame
    protected override void Update()
    {
        // this.transform.LookAt(player.transform.position);

        base.Update();
    }

    protected override void Attack()
    {
        attackEv.Play();

        Debug.Log("HIYA");

        base.Attack();
        Debug.Log(this.gameObject.name + " deals " + attackDamage + " damage to you!");
    }

    public override void TakeDamage(float damage)
    {
        damageEv.Play();

        base.TakeDamage(damage);
    }

    public override void TakeRangedDamage(float damage)
    {
        damageEv.Play();

        base.TakeRangedDamage(damage);
    }

}
