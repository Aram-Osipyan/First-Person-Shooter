using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;
    void Start()
    {
        
    }

    public void MakeDamage(float damage = 40f)
    {
        health -= damage;
        if (health<=0)
        {
            Debug.Log("You are dead!!");
            GetComponent<DeathHandler>().DeathHandle();
        }

    }
    void Update()
    {
        
    }
}
