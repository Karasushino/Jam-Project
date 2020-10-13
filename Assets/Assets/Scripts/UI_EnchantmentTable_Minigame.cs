using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_EnchantmentTable_Minigame : MonoBehaviour
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
   

    public float[] startTime;
    public float[] JourneyLenght;
    private int nRunes;
    public float[] done;
    public float speed;
    public float TimetToWait = 3.0f;
    private int indexResult;
    // Start is called before the first frame update
    void Start()
    {
        nRunes = runes.Length;
        UILimits.Top = 365.0f;
        UILimits.Right = 766f;
        UILimits.Bot = -369.0f;
        UILimits.Left = -746.0f;


        indexResult = 0;
       for (int i = 0; i < nRunes; i++)
        {
            runes[i].GetComponent<RectTransform>().localPosition = new Vector3(Random.Range(UILimits.Left, UILimits.Right),
                Random.Range(UILimits.Bot, UILimits.Top), 0.0f);
            bStopFalling[i] = false;
            done[i] = 0.0f;
            InitializeTransforms(i);
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


    public void GiveButtonLocation()
    {
        Debug.Log("Rune Location. X:" +runes[0].transform.position.x + "Y: " +runes[0].transform.position.y);
    }

    public void StopRune(int r)
    {
        bStopFalling[r] = true;
    }

    void InitializeTransforms(int index)
    {
        randomDestiny[index] = new Vector3(Random.Range(UILimits.Left, UILimits.Right), Random.Range(UILimits.Bot, UILimits.Top), 0.0f);
           
        startTime[index] = Time.time;
        JourneyLenght[index] = Vector3.Distance(runes[index].GetComponent<RectTransform>().localPosition, randomDestiny[index]);
    }
}