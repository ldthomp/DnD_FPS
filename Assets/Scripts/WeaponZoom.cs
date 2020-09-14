﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] RigidbodyFirstPersonController fpsController;
    [SerializeField] float zoomedInFOV = 40;
    [SerializeField] float zoomedOutFOV = 60;

    [SerializeField] float mouseSensitivityDefault = 2f;
    [SerializeField] float mouseSensitivityZoomedFOV = 0.5f;

    void Update()
    {
        ChangeFieldOfView();
        
    }
    private void OnDisable()
    {
        ZoomOut();
    }
    private void ChangeFieldOfView()
    {
        if (Input.GetMouseButton(1))
        {
            ZoomIn();
        }
        else
        {
            ZoomOut();
        }

    }

    private void ZoomIn()
    {
        FPCamera.fieldOfView = zoomedInFOV;
        fpsController.mouseLook.XSensitivity = mouseSensitivityZoomedFOV;
        fpsController.mouseLook.YSensitivity = mouseSensitivityZoomedFOV;
    }

    private void ZoomOut()
    {
        FPCamera.fieldOfView = zoomedOutFOV;
        fpsController.mouseLook.XSensitivity = mouseSensitivityDefault;
        fpsController.mouseLook.YSensitivity = mouseSensitivityDefault;
    }
}
