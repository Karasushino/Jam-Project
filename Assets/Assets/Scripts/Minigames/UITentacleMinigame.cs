using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UITentacleMinigame : MonoBehaviour
{
    // Start is called before the first frame update

    public Slider flaskBar;

    public TextMeshProUGUI flaskText;

    private float objectivePorcentage = 90.0f;
    private float currentPorcentage = 1.0f;
    private float porcToAddPerClick = 2.0f;
    private float maxPorcentage = 100.0f;

    private float percentageOfTempBar = 0.0f;
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void UpdateTemperatureBar()
    {
        //Calculate percentage of bar filled based on max temperature
        percentageOfTempBar = (currentPorcentage / maxPorcentage);

        //User percentage to update fill the temperature bar correctly
        flaskBar.value = percentageOfTempBar;

    

        //Now update the text on the screen.
        int roundTemperature = (int)currentPorcentage;
       // temperatureText.text = roundTemperature.ToString();

    }
    
}
