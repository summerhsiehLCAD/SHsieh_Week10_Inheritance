using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript1 : MonoBehaviour
{
    public BaseEnemy enemy;

    public PlayerRPG player;

    // Start is called before the first frame update
    void Start()
    {
     //   enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<BaseEnemy>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Enemy Hit");

        Debug.Log(collision.gameObject.name);

        if (gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<BaseEnemy>().TakeRangedDamage(3f);

            enemy.TakeRangedDamage(3f);

            Destroy(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }
}
