using System;
using Mirror;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerControler : NetworkBehaviour
{
    public Rigidbody2D RigidBody;
    public float movementSpeed = 5f;
    Vector2 movement;
    public Animator animator;
    public bool bPlayerMovement;
    
    // Start is called before the first frame update
    void Start()
    {
        bPlayerMovement = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (hasAuthority && bPlayerMovement)
        {
            //Gets movement 2DVector from player input.
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            //Gives the movement directions to the blend tree to set animation in animator
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Magnitude", movement.magnitude);

            //Remembers what face the player was looking at and sets idle animation
            if (Mathf.Abs(movement.magnitude) > 0 )
            {
                animator.SetFloat("Last Horizontal", movement.x);
                animator.SetFloat("Last Vertical", movement.y);
            }

            
        }



    }

    void FixedUpdate()
    {
        //Moves the Rigid body
        RigidBody.MovePosition(RigidBody.position + movement * movementSpeed * Time.deltaTime);

    }
    //Enable player movement input
    public void EnableMovement(bool b)
    {
        bPlayerMovement = b;
        //Makes sure to not move player
        movement.x = 0.0f;
        movement.y = 0.0f;
        //Syncs animations
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Magnitude", movement.magnitude);

        //Debug
        Debug.Log("Enable Movement Function was called");
    }

    public bool InputAction()
    {
        return Input.GetButtonDown("Fire1");
    }
}
