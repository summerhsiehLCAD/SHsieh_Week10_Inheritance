using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvolvedSlimeEnemy : BaseEnemy
{
    public AudioScript Audio;

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
        Debug.Log("HIYA");

        base.Attack();
        Debug.Log(this.gameObject.name + " deals " + attackDamage + " damage to you!");

        Audio.attack2SFX.Play();
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);

        Audio.hit2SFX.Play();

    }

    public override void TakeRangedDamage(float damage)
    {
        base.TakeRangedDamage(damage);

        Audio.hit2SFX.Play();
    }

}
