using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Mirror;

public class UI_Potions_Minigame : NetworkBehaviour
{
    public GameObject[] BasePotions;

    public bool[] bSelection;
   // public Image[] BasePotions;
    public Image FinishedPotion;
    public Button exitButton;

    private Color colorA; 
    private Color colorB;
    public TextMeshProUGUI finishText;
    private int nMixBottles;
    public bool bWin;
    public BaseTask potionsTask;
    
    
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);

        nMixBottles = BasePotions.Length;
        colorA = Color.black;
        colorB = Color.black;
        finishText.gameObject.SetActive(false);
        exitButton.interactable = false;
        for (int i = 0; i < nMixBottles; i++)
        {
            bSelection[i] = false;
        }

    }
    public  void SelectBottle(int i)
    {
        bSelection[i] = true;
        if (colorA != Color.black && colorB != Color.black)
        {
            return;
        }
        
        if (colorA == Color.black)
        {
           colorA = BasePotions[i].GetComponent<Image>().color;;
    
        } else if (colorB == Color.black)
        {
            colorB = BasePotions[i].GetComponent<Image>().color;;
        }

        BasePotions[i].GetComponent<Button>().interactable = false;
        
        if (colorA != Color.black && colorB != Color.black)
        {
            MixBottles(); 
        }
    }

 private void MixBottles()
 {
     
     Color finalColor = colorA + colorB;
     FinishedPotion.color = finalColor;
     finishText.gameObject.SetActive(true);
     exitButton.interactable = true;
     if (bSelection[0] && bSelection[2])
     {
         bWin = true;
     }
     else
     {
         bWin = false;
     }
 }

 public void RestartMinigame()
 {
     colorA = Color.black;
     colorB = Color.black;
     FinishedPotion.color = Color.white;
     for (int i = 0; i < nMixBottles; i++)
     {
         BasePotions[i].GetComponent<Button>().interactable = true;
         bSelection[i] = false;
     }
     finishText.gameObject.SetActive(false);
     exitButton.interactable = false;
 }

 public void FinishMinigame()
 {
     potionsTask.CmdSetTaskSuccess(bWin);
     this.gameObject.SetActive(false);
     potionsTask.CmdSetCompleted(true);
     potionsTask.ReturnMovementToPlayerOnUI();
 }
 
}
