using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 30f;
    [SerializeField] float damage = 30f;
    [SerializeField] ParticleSystem muzzleFlash;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        
    }

    private void Shoot()
    {
        PlayMuzzleFlash();
        RaycastingProcess();

    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void RaycastingProcess()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            Debug.Log("I hitted " + hit.transform.name);

            EnemyHealth health = hit.transform.GetComponent<EnemyHealth>();
            health?.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }
}
