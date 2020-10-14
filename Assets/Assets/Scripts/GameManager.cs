using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameManager : NetworkBehaviour
{

    public BaseTask[] tasks;
    [SyncVar]
    public bool CouldronA;
    [SyncVar]
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
    [Command(ignoreAuthority = true)]
    public void CmdSetCouldronA()
    {
        CouldronA = true;
    }
    
    [Command(ignoreAuthority = true)]
    public void CmdSetCouldronB()
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
