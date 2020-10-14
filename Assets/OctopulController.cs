using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopulController : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator OctopusAnimator;
    // Start is called before the first frame update
    public void TriggerTickeOctopusAnim()
    {

        OctopusAnimator.SetTrigger("bTickle");
        Debug.Log("Octopus animation was triggered");

    }
}
