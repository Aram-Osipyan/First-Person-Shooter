using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
public class WeaponZoom : MonoBehaviour
{
    private bool isIn = false;
    [SerializeField] float sensitivityZoomedOut = 2f;
    [SerializeField] float sensitivityZoomedIn = 5f;
    [SerializeField] Camera fpsCamera;
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedInFOV = 20f;
    [SerializeField] RigidbodyFirstPersonController rigidbodyFPC;

    private void OnDisable()
    {
        IsIn = false;
        fpsCamera.fieldOfView = zoomedOutFOV;

    }
    public float SensitivityZoomedOut
    {
        set
        {
            sensitivityZoomedOut = value;
            if (!isIn)
            {
                rigidbodyFPC.mouseLook.XSensitivity = value;
                rigidbodyFPC.mouseLook.YSensitivity = value;
            }
            
        }
        get
        {
            return sensitivityZoomedOut;
        }
    }
    public float SensitivityZoomedIn
    {
        set
        {
            
            sensitivityZoomedIn = value;
            if (isIn)
            {
                rigidbodyFPC.mouseLook.XSensitivity = value;
                rigidbodyFPC.mouseLook.YSensitivity = value;
            }

        }
        get
        {
            return sensitivityZoomedIn;
        }
    }
    public bool IsIn
    {
        get
        {
            return isIn;
        }
        set
        {
            
            if (value)
            {
                rigidbodyFPC.mouseLook.XSensitivity = sensitivityZoomedIn;
                rigidbodyFPC.mouseLook.YSensitivity = sensitivityZoomedIn;
            }
            else
            {
               // Debug.Log("Chaneg!!");
                rigidbodyFPC.mouseLook.XSensitivity = sensitivityZoomedOut;
                rigidbodyFPC.mouseLook.YSensitivity = sensitivityZoomedOut;
            }
            isIn = value;
        }
    }
    

    
    void Update()
    {
        rigidbodyFPC.mouseLook.XSensitivity = sensitivityZoomedOut;
        rigidbodyFPC.mouseLook.YSensitivity = sensitivityZoomedOut;
        if (Input.GetMouseButtonDown(1))
        {
            if (isIn)
            {
                fpsCamera.fieldOfView = zoomedOutFOV;
                
            }
            else
            {
                fpsCamera.fieldOfView = zoomedInFOV;
            }
            IsIn = !IsIn;
        }
    }
}
