using System.Collections;
using System.Collections.Generic;
using Mirror.Examples.Pong;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class UICauldronMinigame : MonoBehaviour
{
    //Get the minigame Object to set it inactive once its completed.
    public Slider temperatureBar;
    //Get the Arrow//Text that will move with the temperature bar
    public TextMeshProUGUI temperatureText;
    
    

    //Variables in Editor
    [SerializeField]
    private float temperatureNeeded = 80.0f;
    [SerializeField]
    //The temperature the Cauldron is at the start of the mini game
    private float currentTemperature = 40.0f;
    [SerializeField]
    //The temperature that we add every click
    private float tempToAddPerClick = 3.0f;
    [SerializeField]
    //The max temperature there can be while heating the cauldron.
    private float maxTemperature = 160.0f;
    //The rate temperature drops at.
    [SerializeField]
    private float CoolingRate;

    private float maxCoolingRate = 1.0f;

    public Button buttonHeatUp;
    public Button buttonIngredients;

    //Private variables 
    //The percentage filled of the bar to show the player
    private float percentageOfTempBar = 0.0f;

    public bool TaskSuccess = false;


    void Start()
    {
        CoolingRate = maxCoolingRate;
    }

    // Update is called once per frame
     void Update()
    {
      
       
        UpdateTemperatureBar();
        DecreaseTemperatureOverTime();
     

    }


    //Decrease temperature over time
    void DecreaseTemperatureOverTime()
    {
        if (currentTemperature > 0.0f)
        {
            currentTemperature -= Time.deltaTime * CoolingRate;
            //Debug.Log("Current Temperature: " + currentTemperature.ToString());
        }
        else
        {
            currentTemperature = 0.0f;
        }
    }

    //Function binded to button to increase temperature
    public void IncreaseCauldronTemperature()
    {
        //Add to current temperature
        currentTemperature += tempToAddPerClick;

        //If we added more temperature than we should have set it back to max
        if (currentTemperature > maxTemperature)
            currentTemperature = maxTemperature;
    }

    void CheckIfTemperatureIsCorrect()
    {
        if (currentTemperature == temperatureNeeded)
        {
            TaskSuccess = true;
            Debug.Log("Cauldron Temperature is the correct one");
        }
        else
        {
            TaskSuccess = false;
        }
             
    }

    void UpdateTemperatureBar()
    {
        //Calculate percentage of bar filled based on max temperature
        percentageOfTempBar = (currentTemperature / maxTemperature);

        //User percentage to update fill the temperature bar correctly
        temperatureBar.value = percentageOfTempBar;

    

        //Now update the text on the screen.
        int roundTemperature = (int)currentTemperature;
        temperatureText.text = roundTemperature.ToString();

    }
    
    public void StopCooling()
    {
        CoolingRate = 0.0f;
        CheckIfTemperatureIsCorrect();
        buttonHeatUp.interactable = false;
        buttonIngredients.interactable = false;
    }

   public void RestartMinigame()
    {
        CoolingRate = maxCoolingRate;
        TaskSuccess = false;
        buttonHeatUp.interactable = true;
        buttonIngredients.interactable = true;
    }
    

}
