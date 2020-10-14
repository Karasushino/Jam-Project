using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskLog : MonoBehaviour
{
    //Create Instance For this Object BaseTask Script
    private BaseTask ScriptBaseTask;
    //Array of the different Tasks that this books contains
    public BaseTask[] ThisBookTasks;
    //Array of the Texts inside the book
    public GameObject[] ArrayUITexts;

    public TMP_FontAsset fRune;
    public TMP_FontAsset fEnglish; 

    // Start is called before the first frame update
    void Start()
    {
        //Initialize Base Script of this object
        ScriptBaseTask = this.GetComponent<BaseTask>();
        //Add Descriotion of Task 0 to the UI Text inside this book
        for (int i = 0; i < ThisBookTasks.Length; i++)
        {
            //ArrayUITexts[i].SetText(ThisBookTasks[i].GetComponent<BaseTask>().GetTaskDescription());
             
        }
        
       ThisBookTasks[0].SetActiveTask(true);
    
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < ThisBookTasks.Length; i++)
        {
            if (ThisBookTasks[i].isCompleted())
            {
                ArrayUITexts[i].GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Strikethrough;
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
