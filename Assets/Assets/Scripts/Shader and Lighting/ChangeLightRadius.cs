using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class ChangeLightRadius : MonoBehaviour
{
  
    public float factor = 0.5f;
    float t = 0f;
    //Pointlight Settings
    public Light2D thePointlight;
    public float MinRadius;
    public float MaxRadius;
    public float startingRadius;
    float Radius;



    private void Start()
    {
        Radius = startingRadius;

    }
    void Update()
    {
        // .. and increase the t interpolater
        t += factor * Time.deltaTime;

        // now check if the interpolator has reached 1.0
        // and swap maximum and minimum so game object moves
        // in the opposite direction.
        if (t > 1.0f)
        {
        
            float temp2 = MaxRadius;
            MaxRadius = MinRadius;
            MinRadius = temp2;


            t = 0.0f;
        }

        //Change Light radius
        //Lerp it
        Radius = Mathf.Lerp(MinRadius, MaxRadius, t);
        //Set it
        thePointlight.pointLightOuterRadius = Radius;


    }
}