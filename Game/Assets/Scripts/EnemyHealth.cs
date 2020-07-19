using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    //private bool isDead = false;
    public bool IsDead
    {
        get;
        private set;
        
    }
    private void Start()
    {
        IsDead = false;
    }
    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (IsDead)
        {
            return;
        }
        IsDead = true;
        //   Destroy(gameObject);
        GetComponent<Animator>().SetTrigger("die");
    }
}
