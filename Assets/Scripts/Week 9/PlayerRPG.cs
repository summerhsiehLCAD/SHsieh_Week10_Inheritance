using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRPG : MonoBehaviour
{
    public float maxhealth = 100f;
    public float currenthealth;

    public float attackDamage = 5f;
    public float attackInterval = 1f;

    private float timer;
    private bool isAttackReady = true;

    public Image attackReadyImage;

    public bool PowerPickedUp = false;

    // Start is called before the first frame update
    void Start()
    {
        currenthealth = maxhealth;
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
        currenthealth -= damage;

        if (currenthealth <= 0)
        {
            Debug.Log("YOU DIED");
        }
    }

    public void Healed(float heal)
    {
        currenthealth += heal;

        currenthealth = Mathf.Clamp(currenthealth, 0f, maxhealth);
    }

}
