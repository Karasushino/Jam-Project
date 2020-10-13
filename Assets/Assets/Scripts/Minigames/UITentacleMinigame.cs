using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UITentacleMinigame : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] Tools;

    private bool bHaveTool;

    public Slider flaskBar;

    public TextMeshProUGUI flaskText;

    private float objectivePorcentage = 90.0f;
    private float currentPorcentage = 1.0f;
    private float porcToAddPerClick = 2.0f;
    private float maxPorcentage = 100.0f;

    private float percentageOfTempBar = 0.0f;

    public int iRightTool = 2;
    private int iSelectedTool = 10;
    void Start()
    {

        bHaveTool = false;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateFlaskBar();
        
    }
    
    void UpdateFlaskBar()
    {
        //Calculate percentage of bar filled based on max temperature
        percentageOfTempBar = (currentPorcentage / maxPorcentage);

        //User percentage to update fill the temperature bar correctly
        flaskBar.value = percentageOfTempBar;

    

        //Now update the text on the screen.
        int roundTemperature = (int)currentPorcentage;
        flaskText.text = roundTemperature.ToString();

    }

    public void SelectTool(int i)
    {
        bHaveTool = true;
        iSelectedTool = i;
        for (int a = 0; a < Tools.Length; a++)
        {
            Tools[a].GetComponent<Button>().interactable = false;
        }
    }

    public void RestartMinigame()
    {
        for (int a = 0; a < Tools.Length; a++)
        {
            Tools[a].GetComponent<Button>().interactable = true;
        }
        iSelectedTool = 10;
        bHaveTool = false;
        currentPorcentage = 1;
    }
    
   public void FillFlask()
    {
        if (bHaveTool && currentPorcentage < objectivePorcentage)
        {
            //Add to current temperature
            currentPorcentage += porcToAddPerClick;

            //If we added more temperature than we should have set it back to max
            if (currentPorcentage > maxPorcentage)
                currentPorcentage = maxPorcentage; 
        }
    }
    
}
