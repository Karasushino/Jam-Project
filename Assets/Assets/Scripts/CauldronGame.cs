using System.Collections;
using System.Collections.Generic;
using Mirror.Examples.Pong;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
public class CauldronGame : BaseTask
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
    //[SerializeField]
    //The temperature that we add every click
    private float tempToAddPerClick = 5.0f;
    [SerializeField]
    //The max temperature there can be while heating the cauldron.
    private float maxTemperature = 160.0f;
    //The rate temperature drops at.
    [SerializeField]
    public float CoolingRate = 2.0f;
    [SerializeField]
    public float currentCoolingRate = 2.0f;
    //Private variables 
    //The percentage filled of the bar to show the player
    private float percentageOfTempBar = 0.0f;


    protected override void Awake()
    {
        base.Awake();
        sDescription = "Increment the cauldron temperature to " + temperatureNeeded + "º";
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
       // if (!bSuccess)
       // {
            UpdateTemperatureBar();
        CheckIfTemperatureIsCorrect();
        DecreaseTemperatureOverTime();
       // }
       // else
       //{
       //Disable it
       // EnableUITask(false);

        // Player.GetComponent<PlayerControler>().EnableMovement(true);
        // ReturnMovementToPlayerOnUI();
        //  }

        

    }


    //Decrease temperature over time
    void DecreaseTemperatureOverTime()
    {
        if (currentTemperature > 0.0f)
        {
            currentTemperature -= Time.deltaTime * currentCoolingRate;
            Debug.Log("Current Temperature: " + (Mathf.Round(currentTemperature)));
        }
        else
        {
            currentTemperature = 0.0f;
        }
    }

    //Function binded to button to increase temperature
    public void IncreaseCauldronTemperature()
    {
        currentCoolingRate = CoolingRate;
        //Add to current temperature
        currentTemperature += tempToAddPerClick;

        //If we added more temperature than we should have set it back to max
        if (currentTemperature > maxTemperature)
            currentTemperature = maxTemperature;
    }

    bool CheckIfTemperatureIsCorrect()
    {
        if (Mathf.Round(currentTemperature) == temperatureNeeded)
        {
            bSuccess = true;
            Debug.Log("Task Cauldron Completed");
            return true;
        }
        else
        {
            return false;
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
        currentCoolingRate = 0.0f;

        if (CheckIfTemperatureIsCorrect())
        {
            SetTaskSuccess(true);
        }
        
    }

}
