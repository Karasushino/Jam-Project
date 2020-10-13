using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class ShaderInensity : MonoBehaviour
{
    // Start is called before the first frame update
    public Material BookMaterial;
    // Update is called once per frame
    Color finalColor;
    public Color originalColor = new Color(191f,183f,0f,255f);
    public float startingIntensity = 4.5f;
    //Intensity to lerp between;
    public float MinIntensity = 0.69f;
    public float MaxIntensity = 2.0f;
     float Intensity = 0.0f;
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
        originalColor = new Color(originalColor.r * startingIntensity, originalColor.g * startingIntensity, originalColor.b * startingIntensity);
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
            float temp = MaxIntensity;
            MaxIntensity = MinIntensity;
            MinIntensity = temp;

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

        //Lerp Intensity of emission
        Intensity = Mathf.Lerp(MinIntensity, MaxIntensity, t);
        finalColor = new Color(originalColor.r * Intensity, originalColor.g * Intensity, originalColor.b * Intensity);
        //Set the Color
        BookMaterial.SetColor("_Color", finalColor);



        //Debug.Log("Intensity = " + Intensity.ToString());
        //Debug.Log("t = " + t.ToString());

    }
}
