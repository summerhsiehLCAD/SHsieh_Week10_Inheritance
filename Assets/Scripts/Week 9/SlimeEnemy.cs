using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeEnemy : BaseEnemy
{
    public AudioSource attackNorm;
    public AudioSource damageNorm;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        Debug.Log("HeeHo I'm a slime!");
    }

    // Update is called once per frame
    protected override void Update()
    {
       // this.transform.LookAt(player.transform.position);

        base.Update();
    }

    protected override void Attack()
    {
        attackNorm.Play();

        Debug.Log("HIYA");

        base.Attack();
        Debug.Log(this.gameObject.name + " deals " + attackDamage + " damage to you!");

    }

    public override void TakeDamage(float damage)
    {
        damageNorm.Play();

        base.TakeDamage(damage);
    }

    public override void TakeRangedDamage(float damage)
    {
        damageNorm.Play();

        base.TakeRangedDamage(damage);
    }

}
