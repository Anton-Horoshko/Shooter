using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;
    public float detectionRange = 10f;
    public float idleWanderRadius = 3f;
    private Vector3 idleTarget;
    private float idleTimer;
    private float idleWaitTime = 2f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
            {
                player = playerObj.transform;
            }
            else
            {
                Debug.LogWarning("EnemyAI: Не найден объект с тегом Player!");
            }
        }

        ChooseNewIdleTarget();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            ChasePlayer();
        }
        else
        {
            IdleWander();
        }
    }

    void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    void IdleWander()
    {
        idleTimer += Time.deltaTime;

        if (idleTimer >= idleWaitTime || Vector3.Distance(transform.position, idleTarget) < 1f)
        {
            ChooseNewIdleTarget();
            idleTimer = 0f;
        }

        agent.SetDestination(idleTarget);
    }

    void ChooseNewIdleTarget()
    {
        Vector3 randomDirection = Random.insideUnitSphere * idleWanderRadius;
        randomDirection += transform.position;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, idleWanderRadius, NavMesh.AllAreas))
        {
            idleTarget = hit.position;
        }
        else
        {
            idleTarget = transform.position;
        }
    }
}
