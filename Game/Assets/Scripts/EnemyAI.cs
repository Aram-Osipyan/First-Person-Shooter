using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    NavMeshAgent navMeshAgent;
    [SerializeField] float chaseRange = 5f;
    bool isProvoked = false;
    Animator enemies;
    // Start is called before the first frame update
    void Start()
    {
        enemies = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(target.position);
    }

    // Update is called once per frame
    void Update()
    {
        var len = Vector3.Distance(gameObject.transform.position , target.position);
        //navMeshAgent.SetDestination(target.position);
        if (isProvoked)
        {
            EngageTarget(len);
        }
        else if (len < chaseRange)
        {
            isProvoked = true;
        }
            
        
    }

    private void EngageTarget(float len)
    {
        if (len>=navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        else
        {
            AttackTarget();
        }
    }

    private void AttackTarget()
    {
       
        enemies.SetTrigger("attack");
    }

    private void ChaseTarget()
    {
        enemies.SetTrigger("move");
        
        navMeshAgent.SetDestination(target.position);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
