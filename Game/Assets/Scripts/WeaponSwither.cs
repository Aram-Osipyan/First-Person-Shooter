using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwither : MonoBehaviour
{
    [SerializeField] List<Weapon> weapons;
    int currentWeapon = 0;
    
    void Start()
    {
        foreach (var item in weapons)
        {
            item.gameObject.SetActive(false);
        }
        weapons[0].gameObject.SetActive(true);
    }

    void SetActiveWeapon(int index)
    {
        index %= weapons.Count;
        weapons[currentWeapon].gameObject.SetActive(false);
        weapons[index].gameObject.SetActive(true);
        currentWeapon = index;
    }
    void Update()
    {
        ProcessKeyInput();
        //ProcessScrollWheel();
    }

    private void ProcessScrollWheel()
    {
        if (Input.GetAxis("Mouse ScrollWheel")>0)
        {
            SetActiveWeapon(currentWeapon + 1);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            SetActiveWeapon(currentWeapon - 1);
        }
    }

    private void ProcessKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetActiveWeapon(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetActiveWeapon(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetActiveWeapon(2);
        }
    }
}
