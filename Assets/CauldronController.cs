using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CauldronController : MonoBehaviour
{
    public Animator cauldronAnimator;
    // Start is called before the first frame update
   public void TriggerHeatUpCauldronAnim()
    {

        cauldronAnimator.SetTrigger("bHeatingUp");
        Debug.Log("Cauldron anim changed to heat up");
       
    }
}
