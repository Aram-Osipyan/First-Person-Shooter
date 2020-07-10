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
    [SerializeField] GameObject explosion;
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
            CreateExposion(hit);
            EnemyHealth health = hit.transform.GetComponent<EnemyHealth>();
            health?.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }

    private void CreateExposion(RaycastHit hit)
    {
        Destroy(Instantiate(explosion, hit.point,Quaternion.LookRotation(hit.normal)),1);
    }
}
