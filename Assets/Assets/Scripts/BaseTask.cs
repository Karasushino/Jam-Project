using System;
using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class BaseTask : NetworkBehaviour
{
     public String DesiredPlayerTag;
     
    //Object for the task Graphic Representation
    public GameObject UITask;
    //Flag true if the player is inside this object range
    private bool bPlayerIn;
    //Player Instance in This Object
    public GameObject Player;
    //String With This Task Description
    public  String sDescription;
    //String For This Task Name
    private String sTaskName;
    //Flag is this Task is active or sleeping
    [SyncVar]
    public bool bIsActiveTask;
    //Task if succeed or failure in this task. 
    [SyncVar]
    public bool bSuccess;
    [SyncVar]
    public bool bCompleted;
   // public TaskLog taskLog; 
    
    
    
    ////////////////////////////////// MAIN FUNCTIONS  //////////////////////////////////
    
    // Start is called before the first frame update
    void Start()
    {

    //    bIsActiveTask = false;
      //  bSuccess = false;
     //   bCompleted = false;
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
        //If the player is in Range of the Task...
        if (bPlayerIn && IsTaskActive())
        {
            this.GetComponent<NetworkIdentity>().AssignClientAuthority(Player.GetComponent<NetworkIdentity>().connectionToClient);
            //... and it pushes the "Fire1" button..
            if (Input.GetButtonDown("Fire1") && hasAuthority)
            {
                
                //Enable the UI Task Minigame
                EnableUITask(true);
                //Restrict Player Movement while using the task.
                Player.GetComponent<PlayerControler>().EnableMovement(false);
            }

        }
    }

    ////////////////////////////////// EVENTS //////////////////////////////////
    public void OnTriggerEnter2D(Collider2D other)
    {
        //If the player Enters In the trigger of this object. 
        if (other.gameObject.CompareTag(DesiredPlayerTag))
        {
            //Flag Player Entrance
            bPlayerIn = true;
            //... if player instance is empty...
            if (!Player)
            {
                //Get Player's Game Object
                Player = other.gameObject;
             
            }

        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        //When the player leaves the trigger
        if (other.gameObject.CompareTag(DesiredPlayerTag))
        {
            //... set flag to false
            bPlayerIn = false;
        }
    }
    
    ////////////////////////////////// SETTERS //////////////////////////////////
    
    //Set Active/Unactive the UI Task asigned to this object
    public void EnableUITask(bool boolean)
    {
        UITask.gameObject.SetActive(boolean);
    }
    
    //Set if the task is active or not
    public void SetActiveTask(bool b)
    {
        bIsActiveTask = b;
    //    bCompleted = false;
    }

    public bool isCompleted()
    {
        return bCompleted;
    }
    [Command(ignoreAuthority = true)]
    public void CmdSetCompleted(bool b)
    {
        bCompleted = b;
    }

    //Set task result
    [Command(ignoreAuthority = true)]
    public void CmdSetTaskSuccess(bool b)
    {
        bSuccess = b;
        
    }
    //Set The Task Description
    public void CmdSetTaskDescription(string s)
    {
        sDescription = s;
    }
    ////////////////////////////////// GETTERS //////////////////////////////////
    
    //Get if the task is active or not
    public bool IsTaskActive()
    {
        return bIsActiveTask;
    }
    [Command(ignoreAuthority = true)]
    public void setActiveTask(bool b)
    {
        bIsActiveTask = b;
    }
    
    //Get if the task is success or failure
    public bool GetTaskSuccess()
    {
        return bSuccess;
    }
    
    //Get The task description string
    public string GetTaskDescription()
    {
        return sDescription;
    }

    ////////////////////////////////// GENERAL FUNCTIONS //////////////////////////////////

    // Give Back Movement to the player when the UI task is closed
    public void ReturnMovementToPlayerOnUI()
    {
   
            //Debug
            Debug.Log("ReturnMovementToPlayerOnUI() was called with a player");
            Player.GetComponent<PlayerControler>().EnableMovement(true);
  
            //Debug.Log("ReturnMovementToPlayerOnUI() was called with no player object")

    }
    
}
