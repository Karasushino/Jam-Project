using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseTask : MonoBehaviour
{

    public GameObject UITask;
    private bool bPlayerIn;
    private GameObject Player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bPlayerIn)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                EnableUITask(true);
  
                Player.GetComponent<PlayerControler>().EnableMovement(false);
                
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            bPlayerIn = true;
            Player = other.gameObject;
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            bPlayerIn = false;
        }
    }
    public void EnableUITask(bool boolean)
    {
        UITask.gameObject.SetActive(boolean);
    }


    public void EnablePlayerMovement()
    {
        Player.GetComponent<PlayerControler>().EnableMovement(true);
    }
}
