using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera POVCamera;
    [SerializeField] float zoomOut = 40f;
    [SerializeField] float zoomIn = 25f;
    [SerializeField] [Range(0.5f, 5.0f)]float zoomInSensitivity = 1f;
    [SerializeField] [Range(0.5f, 5.0f)]float zoomOutSensitivity = 5f;

    public bool isZoomed = false;
    FirstPersonController firstPersonController;

    void Start()
    {
      firstPersonController = GetComponent<FirstPersonController>();
    }

    void Update()
    {
        ZoomIn();
    }

    private void ZoomIn()
    {
        if(Input.GetButtonDown("Fire2"))
        {
            if(isZoomed == true)
            {
                POVCamera.m_Lens.FieldOfView = zoomIn;
                isZoomed = false;
                firstPersonController.RotationSpeed = zoomInSensitivity;
            }
            else
            {
                POVCamera.m_Lens.FieldOfView = zoomOut;
                isZoomed = true;
                firstPersonController.RotationSpeed = zoomOutSensitivity;
            }
        }
    }
}
