using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskLog : MonoBehaviour
{
    //Create Instance For this Object BaseTask Script
    private BaseTask ScriptBaseTask;
    //Array of the different Tasks that this books contains
    public GameObject[] ThisBookTasks;
    //Array of the Texts inside the book
    public Text[] ArrayUITexts;
    
    // Start is called before the first frame update
    void Start()
    {
        //Initialize Base Script of this object
        ScriptBaseTask = this.GetComponent<BaseTask>();
        //Add Descriotion of Task 0 to the UI Text inside this book
        ArrayUITexts[0].text = ThisBookTasks[0].GetComponent<BaseTask>().GetTaskDescription();
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
}
