using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_EnchantmentTable_Minigame : NetworkBehaviour
{

    public GameObject[] runes;

    public Vector3[] randomDestiny;
    struct Limits
    {
        public float Top;
        public float Bot;
        public float Right;
        public float Left;
    }

    private Limits UILimits;

    public bool[] bStopFalling;

    public BaseTask baseTask;

    public float[] startTime;
    public float[] JourneyLenght;
    public bool[] bSelected;
    private int nRunes;
    public float[] done;
    public float speed;
    public float TimetToWait = 3.0f;
    public int indexResult;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);

        nRunes = runes.Length;
        UILimits.Top = 300.0f;
        UILimits.Right = 300f;
        UILimits.Bot = -300.0f;
        UILimits.Left = -300.0f;


        indexResult = 0;
       for (int i = 0; i < nRunes; i++)
        {
            runes[i].GetComponent<RectTransform>().localPosition = new Vector3(Random.Range(UILimits.Left, UILimits.Right),
                Random.Range(UILimits.Bot, UILimits.Top), 0.0f);
            bStopFalling[i] = false;
            done[i] = 0.0f;
            InitializeTransforms(i);
            bSelected[i] = false;
            
        }
    }
    
    // Update is called once per frame
    void Update()
    {

        
        
        float distCovered = Time.deltaTime * speed;
        
        for (int i = 0; i < nRunes; i++)
        {
            if (!bStopFalling[i])
            {

                Vector3 rectTransform = runes[i].GetComponent<RectTransform>().localPosition;
                
                float fractionOfJourney = distCovered / JourneyLenght[i];

                runes[i].GetComponent<RectTransform>().localPosition =
                    Vector3.Lerp(rectTransform, randomDestiny[i], distCovered);

                if (Time.time > done[i])
                {
                    done[i] = Time.time + TimetToWait;
                    InitializeTransforms(i);
                    
                }
            }
        }

    }



    public void StopRune(int r)
    {
        runes[r].GetComponent<Button>().interactable = false;
        bStopFalling[r] = true;
        bSelected[r] = true;
        indexResult++;
        if (indexResult == 3)
        {
            if (bSelected[0] && bSelected[2] && bSelected[4])
            {
                baseTask.CmdSetTaskSuccess(true);
                baseTask.ReturnMovementToPlayerOnUI();
                this.gameObject.SetActive(false);
                baseTask.CmdSetCompleted(true);
            }
            else
            {
                baseTask.CmdSetTaskSuccess(false);
                baseTask.ReturnMovementToPlayerOnUI();
                this.gameObject.SetActive(false);
                baseTask.CmdSetCompleted(true);
            }
        }
    }

    void InitializeTransforms(int index)
    {
        randomDestiny[index] = new Vector3(Random.Range(UILimits.Left, UILimits.Right), Random.Range(UILimits.Bot, UILimits.Top), 0.0f);
           
        startTime[index] = Time.time;
        JourneyLenght[index] = Vector3.Distance(runes[index].GetComponent<RectTransform>().localPosition, randomDestiny[index]);
    }

   public void Restart()
    {
        for (int i = 0; i < runes.Length; i++)
        {
            runes[i].GetComponent<Button>().interactable = true;
            bStopFalling[i] = false;
            bSelected[i] = false;
            indexResult = 0;
        }
        baseTask.CmdSetTaskSuccess(false);
    }
    
}
