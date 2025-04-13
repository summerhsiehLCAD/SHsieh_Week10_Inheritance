using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNav : EvolvedSlimeEnemy
{
    public BaseEnemy baseEnemyScript;

    [SerializeField]
    protected float aggroRange = 10f;

    protected NavMeshAgent navAgent;

    protected bool hasSeenPlayer = false;

    protected int patrolPointIndex = 0;

    [SerializeField]
    protected List<Transform> patrolPoints = new List<Transform>();

    // Start is called before the first frame update
    protected override void Start()
    {
        player = FindAnyObjectByType<PlayerRPG>();
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.SetDestination(patrolPoints[patrolPointIndex].position);
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (hasSeenPlayer == true)
        {
            if (navAgent.remainingDistance < 0.5f)
            {
                if (Vector3.Distance(this.transform.position, player.transform.position) > aggroRange)
                {
                    hasSeenPlayer = false;
                    navAgent.isStopped = false;
                }
                else
                {
                    if (IsPlayerInLos() == true)
                    {
                        navAgent.SetDestination(player.transform.position);
                        navAgent.isStopped = true;
                    }
                    else
                    {
                        hasSeenPlayer = false;
                        navAgent.isStopped = false;
                    }
                }
            }

            if (Vector3.Distance(this.transform.position, player.transform.position) > attackRange)
            {
                if (IsPlayerInLos() == true)
                {
                    navAgent.SetDestination(player.transform.position);
                    navAgent.isStopped = false;
                }
            }
            else
            {
                if (IsPlayerInLos() == true)
                {
                    navAgent.isStopped = true;
                    this.transform.LookAt(player.transform.position);

                    timer += Time.deltaTime;

                    if (timer > speed)
                    {
                        Attack();
                        timer = 0;
                    }
                }
                else
                {
                    navAgent.isStopped = false;
                }
            }
        }
        else
        {
            if (navAgent.remainingDistance < 0.5f)
            {
                patrolPointIndex++;

                if (patrolPointIndex >= patrolPoints.Count)
                {
                    patrolPointIndex = 0;
                }

                navAgent.SetDestination(patrolPoints[patrolPointIndex].position);
                navAgent.isStopped = false;
            }
        }

    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            hasSeenPlayer = true;
        }
    }

    public void SeePlayer()
    {
        RaycastHit hit;

        Vector3 dir = player.transform.position - this.transform.position;
        dir.Normalize();

        if (Physics.Raycast(this.transform.position, dir, out hit))
        {
            if (hit.collider.tag == "Player")
            {
                hasSeenPlayer = true;
            }
        }

    }

    protected bool IsPlayerInLos()
    {
        RaycastHit hit;

        Vector3 dir = player.transform.position - this.transform.position;
        dir.Normalize();

        if (Physics.Raycast(this.transform.position, dir, out hit))
        {
            Debug.Log(hit.collider.name);

            if (hit.collider.tag == "Player")
            {
                return true;
            }
        }

        return false;
    }
}
