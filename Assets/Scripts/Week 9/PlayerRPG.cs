using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRPG : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;

    public float attackDamage = 5f;
    public float attackInterval = 1f;

    private float timer;
    private bool isAttackReady = true;

    public Image attackReadyImage;

    public bool powerPickedUp = false;

    public int maxAmmo = 20;
    public int currentAmmo;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if(isAttackReady == false)
        {
            timer += Time.deltaTime;

            if (timer >= attackInterval)
            {
                isAttackReady = true;
                attackReadyImage.gameObject.SetActive(isAttackReady);
                timer = 0f;
            }
        }
        

        if(Input.GetMouseButtonDown(0))
        {
            if(isAttackReady == true)
            {
                RaycastHit hit;

                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 3f))
                {
                    BaseEnemy enemy = hit.collider.GetComponent<BaseEnemy>();

                    if (enemy != null)
                    {
                        Attack(enemy);
                    }
                }
            }
        }
    }

    public void Attack(BaseEnemy enemy)
    {
        enemy.TakeDamage(attackDamage);
        isAttackReady = false;
        attackReadyImage.gameObject.SetActive(isAttackReady);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Debug.Log("YOU DIED");
        }
    }

    public void AmmoAmount()
    {
   
        if (currentAmmo > 0)
        {
            // make a count down based on every shot taken
        }

        else if (currentAmmo <= 0)
        {
            // ran out of ammo, can't shot
            Debug.Log("Out of Ammo");
        }
    }
}
