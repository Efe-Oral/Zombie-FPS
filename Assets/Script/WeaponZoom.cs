using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera POVCamera;
    [SerializeField] FirstPersonController firstPersonController;
    [SerializeField] float zoomOut = 40f;
    [SerializeField] float zoomIn = 25f;
    [SerializeField] [Range(0.1f, 5.0f)]float zoomInSensitivity = 1f;
    [SerializeField] [Range(0.1f, 5.0f)]float zoomOutSensitivity = 5f;

    public bool isZoomed = false;

    private void OnDisable()
    {
        ZoomOut();
    }

    void Update()
    {
        ZoomIn();
    }

    private void ZoomIn()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if(isZoomed == true)
            {
                POVCamera.m_Lens.FieldOfView = zoomOut;
                firstPersonController.RotationSpeed = zoomOutSensitivity;
                isZoomed = false;
            }
            else
            {
                POVCamera.m_Lens.FieldOfView = zoomIn;
                firstPersonController.RotationSpeed = zoomInSensitivity;
                isZoomed = true;
            }
        }
    }
    private void ZoomOut()
    {
        POVCamera.m_Lens.FieldOfView = zoomOut;
        firstPersonController.RotationSpeed = zoomOutSensitivity;
        isZoomed = false;
    }
}
