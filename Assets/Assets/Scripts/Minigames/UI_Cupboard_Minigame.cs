using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class UI_Cupboard_Minigame : NetworkBehaviour
{
    /**Important Disclaimer*/

    [SerializeField]
    private int numberOfObjects = 6;
    //The index of the element of the array of objects that will be the correct one to pick.
    [SerializeField]
    private int IndexOfCorrectObject;
    //Has any selection happened?
    private bool bAnySelection = false;
    //Array of booleans for each object.
    private bool[] bObjectSelected;
    //Is the correct object selected?
    public bool bCorrectSlection = false;

    public BaseTask cupboardTask;



    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
        //Changes number of objects to index suitable.

        //Create a set array of bool.
        bObjectSelected = new bool[numberOfObjects];
        numberOfObjects -= 1;
        //Pick a random correct Object.
        
    }
    


    public void SelectObject(int i)
    {
        //Select object and store that it was selected also store which one was selected.
        //For possibly extending this later on.
        if (!bAnySelection)
        {
            //smth has been selected, don't let select again unless restart.
            bAnySelection = true;
            //Mark object as selected.
            bObjectSelected[i] = true;
            Debug.Log("There was a selection, selection locked");

            //Checks to see if the selected object is the set as correct one.
            if (i == IndexOfCorrectObject)
            {
                bCorrectSlection = true;
                cupboardTask.CmdSetTaskSuccess(bCorrectSlection);
                Debug.Log("Correct Selection");
                cupboardTask.ReturnMovementToPlayerOnUI();
                cupboardTask.CmdSetCompleted(true);
                this.gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("Wrong Selection");
                cupboardTask.CmdSetTaskSuccess(bCorrectSlection);
                cupboardTask.ReturnMovementToPlayerOnUI();
                cupboardTask.CmdSetCompleted(true);
                this.gameObject.SetActive(false);
                
            }
                

        }
        Debug.Log("SelectObject called but selection is locked");
    }

    public void RestartSelection()
    {
        //Set all the array to false
        for (int i = 0; i < numberOfObjects; i++)
            bObjectSelected[i] = false;

        bAnySelection = false;
        cupboardTask.CmdSetTaskSuccess(false);
        Debug.Log("Selection Unlocked, you can reselect now");
    }

}
