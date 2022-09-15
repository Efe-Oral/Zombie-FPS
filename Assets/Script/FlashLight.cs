using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    [SerializeField] float lightDecay = 10;
    [SerializeField] float angleDecay = 60;
    [SerializeField] float minimumAngle = 20f;

    Light myLight;

    void Start()
    {
        myLight = GetComponent<Light>();
    }

    private void Update()
    {
        DecraseLightAngle();
        DecraseLightIntensity();
    }

    private void DecraseLightAngle()
    {
        myLight.spotAngle -= angleDecay * Time.deltaTime;
        if(myLight.spotAngle < minimumAngle)
        {
            myLight.spotAngle = minimumAngle;
        }
    }

    private void DecraseLightIntensity()
    {
        myLight.intensity -= lightDecay * Time.deltaTime;
        if(myLight.intensity < 2)
        {
            myLight.intensity = 2;
        }
    }
}
