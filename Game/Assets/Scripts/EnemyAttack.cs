using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Transform target;
    void Start()
    {
        
    }

    public void Attack()
    {
        if (target == null)
        {
            return;
        }

        Debug.Log("ATTTTAAAACK!!!");
    }
}
