using System.Collections;
using System.Collections.Generic;
using Mirror.Examples.Pong;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
public class CauldronGame : BaseTask
{
    //Get the minigame Object to set it inactive once its completed.
    public Slider temperatureBar;
    //Get the Arrow//Text that will move with the temperature bar
    public Image temperatureArrow;


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
    //The rate temperature drops at.
    [SerializeField]
    private float CoolingRate = 1.0f;


    Vector3 ArrowPosition;
    Vector3 FinalArrowPosition;

    float BarHeight;
    //Private variables 
    //The percentage filled of the bar to show the player
    private float percentageOfTempBar = 0.0f;



    private void Start()
    {
        //Bar Position is W

        //Get Height of Bar
        BarHeight = temperatureBar.GetComponent<RectTransform>().rect.height;
        //Bar position is centered, so to get the arrow at the bottom take the bar height, half it and subtract it fromt the local position. 
        float startingY = -(BarHeight / 2) + temperatureBar.transform.localPosition.y;
        //Just set the starting position.
        ArrowPosition = new Vector3(temperatureBar.transform.localPosition.x - temperatureArrow.rectTransform.rect.width, startingY, temperatureArrow.transform.localPosition.z);

        temperatureArrow.transform.localPosition = ArrowPosition;



       
        //Debug.Log(-(BarHeight/2)+temperatureBar.transform.localPosition.y);


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
            currentTemperature -= Time.deltaTime * CoolingRate;
            Debug.Log("Current Temperature: " + currentTemperature.ToString());
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

        float calculateY = ArrowPosition.y + BarHeight * percentageOfTempBar;

        FinalArrowPosition = new Vector3(ArrowPosition.x, calculateY, ArrowPosition.z);

        temperatureArrow.transform.localPosition = FinalArrowPosition;



        Debug.Log(calculateY);




    }


}
