using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    NavMeshAgent navMeshAgent;
    [SerializeField] float chaseRange = 5f;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(target.position);
    }

    // Update is called once per frame
    void Update()
    {
        var len = Vector3.Distance(gameObject.transform.position , target.position);

        if (len < chaseRange)
            navMeshAgent.SetDestination(target.position);
        //else
            //navMeshAgent.SetDestination(gameObject.transform.position);
    }
}
