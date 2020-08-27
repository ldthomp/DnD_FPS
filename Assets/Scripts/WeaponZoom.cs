using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float zoomedInFOV = 40;
    [SerializeField] float zoomedOutFOV = 60;

    [SerializeField] float mouseSensitivityDefault = 2f;
    [SerializeField] float mouseSensitivityZoomedFOV = 0.5f;

    RigidbodyFirstPersonController fpsController;

    void Update()
    {
        ChangeFieldOfView();
        
    }

    private void ChangeFieldOfView()
    {
        if (Input.GetMouseButton(1))
        {
            FPCamera.fieldOfView = zoomedInFOV;
            fpsController.mouseLook.XSensitivity = mouseSensitivityZoomedFOV;
            fpsController.mouseLook.YSensitivity = mouseSensitivityZoomedFOV;
        }
        else
        {
            FPCamera.fieldOfView = zoomedOutFOV;
            fpsController.mouseLook.XSensitivity = mouseSensitivityDefault;
            fpsController.mouseLook.YSensitivity = mouseSensitivityDefault;
        }

    }
}
