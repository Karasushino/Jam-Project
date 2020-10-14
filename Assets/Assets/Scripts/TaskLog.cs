using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskLog : MonoBehaviour
{

    //Array of the different Tasks that this books contains
    public BaseTask[] ThisBookTasks;
    //Array of the Texts inside the book
    public GameObject[] ArrayUITexts;

    public TMP_FontAsset fRune;
    public TMP_FontAsset fEnglish; 

    // Start is called before the first frame update
    public int activeTasks = 0;

    private void Start()
    {
        ThisBookTasks[0].SetActiveTask(true);

        for (int i = 0; i < ThisBookTasks.Length; i++)
        {
            ArrayUITexts[i].GetComponent<TextMeshProUGUI>().text = ThisBookTasks[i].GetTaskDescription();
        }
    }

    // Update is called once per frame
    void Update()
    {



        
        for (int i = 0; i < ThisBookTasks.Length; i++)
        {
           
            if (ThisBookTasks[i].isCompleted())
            {
                ArrayUITexts[i].GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Strikethrough;
                if (i + 1 < 3)
                {
                    ThisBookTasks[i+1].SetActiveTask(true);
                }
                
            }

            if (ThisBookTasks[i].IsTaskActive())
            {
                ArrayUITexts[i].GetComponent<TextMeshProUGUI>().font = fEnglish;
            }
            else
            {
                ArrayUITexts[i].GetComponent<TextMeshProUGUI>().font = fRune;
            }
        }
    }
   
}
