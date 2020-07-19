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
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] float timeBetweenShots = 1f;
    bool canShoot = true;
    void Start()
    {
        
    }

    private void OnEnable()
    {
        canShoot = true;
    }
    
    void Update()
    {
        if (Input.GetMouseButton(0) && !ammoSlot.IsEmpty(ammoType) && canShoot)
        {
            ammoSlot.ReduceCurrentAmmo(ammoType);
            StartCoroutine(Shoot());
        }
        
    }

    private IEnumerator Shoot()
    {
        canShoot = false;
        PlayMuzzleFlash();
        RaycastingProcess();
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;

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
