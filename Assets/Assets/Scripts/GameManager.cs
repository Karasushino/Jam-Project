using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public BaseTask[] tasks;
    public bool CouldronA;
    public bool CouldronB;
    public bool Flag;

    public GameObject objWin;
    public GameObject objDefeat;

    public int cErrors;
    // Start is called before the first frame update
    void Start()
    {
        cErrors = 0;
        Flag = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (CouldronA && CouldronB && Flag)
        {
            Flag = false;
            for (int i = 0; i < tasks.Length; i++)
            {
                if (!tasks[i].GetTaskSuccess())
                {
                    cErrors++;
                }
            }

            if (cErrors > 0)
            {
                Defeat();
            }
            else
            {
                Win();
            }
        }
    }

    public void setCouldronA()
    {
        CouldronA = true;
    }
    
    
    public void setCouldronB()
    {
        CouldronB = true;
    }

    public void Win()
    {
        objWin.SetActive(true);
    }

    public void Defeat()
    {
        objDefeat.SetActive(true);
    }

}
