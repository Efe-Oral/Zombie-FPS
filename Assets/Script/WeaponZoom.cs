using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera POVCamera;
    public bool isZoomed = false;

    // Update is called once per frame
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
                POVCamera.m_Lens.FieldOfView = 25f;
                isZoomed = false;
            }
            else
            {
                POVCamera.m_Lens.FieldOfView = 40f;
                isZoomed = true;
            }
        }
    }
}
