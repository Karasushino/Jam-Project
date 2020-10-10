using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.UIElements;
using UnityEngine;

public class ShaderInensity : MonoBehaviour
{
    // Start is called before the first frame update
    public Material BookMaterial;
    // Update is called once per frame
    Color finalColor;
    Color originalColor;
    //Intensity to lerp between;
    public float MinIntensity = 0.69f;
    public float MaxIntensity = 2.0f;
     float Intensity = 0.0f;
    public float factor = 0.5f;
    float t = 0f;


    private void Start()
    {
        originalColor = BookMaterial.GetVector("_Color");
        
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
            t = 0.0f;
        }



        Intensity = Mathf.Lerp(MinIntensity, MaxIntensity, t);
        finalColor = new Color(originalColor.r * Intensity, originalColor.g * Intensity, originalColor.b * Intensity);
        BookMaterial.SetColor("_Color", finalColor);
        //Debug.Log("Intensity = " + Intensity.ToString());
        Debug.Log("t = " + t.ToString());

    }
}
