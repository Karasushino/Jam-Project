using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UI_Potions_Minigame : MonoBehaviour
{
    public GameObject[] BasePotions;
   // public Image[] BasePotions;
    public Image FinishedPotion;

    private Color colorA; 
    private Color colorB;

    private int nMixBottles; 
    // Start is called before the first frame update
    void Start()
    {
        nMixBottles = BasePotions.Length;
        colorA = Color.black;
        colorB = Color.black;

    }
    public  void SelectBottle(int i)
    {
        
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
 }

 public void RestartMinigame()
 {
     colorA = Color.black;
     colorB = Color.black;
     FinishedPotion.color = Color.white;
     for (int i = 0; i < nMixBottles; i++)
     {
         BasePotions[i].GetComponent<Button>().interactable = true;
     }
 } 
 
}
