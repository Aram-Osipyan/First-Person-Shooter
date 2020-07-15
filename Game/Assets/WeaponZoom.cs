using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
public class WeaponZoom : MonoBehaviour
{
    private bool isIn = false;
    private float sensitivityZoomedOut = 2f;
    private float sensitivityZoomedIn = 5f;
    [SerializeField] Camera fpsCamera;
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedInFOV = 20f;
    [SerializeField] RigidbodyFirstPersonController rigidbodyFPC;
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
    
    void Start()
    {
        
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
            isIn = !isIn;
        }
    }
}
