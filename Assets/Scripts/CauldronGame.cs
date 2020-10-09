using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CauldronGame : BaseTask
{
    //Get the minigame Object to set it inactive once its completed.
    public Slider temperatureBar;

    //Variables in Editor
    [SerializeField]
    private float temperatureNeeded = 80.0f;
    [SerializeField]
    //The temperature the Cauldron is at the start of the mini game
    private float currentTemperature = 40.0f;
    [SerializeField]
    //The temperature that we add every click
    private float tempToAddPerClick = 1.0f;
    [SerializeField]
    //The max temperature there can be while heating the cauldron.
    private float maxTemperature = 160.0f;




    //Private variables 
    //The percentage filled of the bar to show the player
    private float percentageOfTempBar = 0.0f;
    

    // Update is called once per frame
    void Update()
    {
        if (!bSuccess)
        {
            UpdateTemperatureBar();
            CheckIfTemperatureIsCorrect();
        }
        else
        {
            //Disable it
            EnableUITask(false);
            ReturnMovementToPlayerOnUI();
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
            bSuccess = true;
            Debug.Log("Task Cauldron Completed");
        }
            
    }

    void UpdateTemperatureBar()
    {
        //Calculate percentage of bar filled based on max temperature
        percentageOfTempBar = (currentTemperature / maxTemperature);

        //User percentage to update fill the temperature bar correctly
        temperatureBar.value = percentageOfTempBar;

    }

   
}
