using Mirror;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerControler : NetworkBehaviour
{
    public Rigidbody2D RigidBody;
    public float movementSpeed = 5f;
    Vector2 movement;


    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    [Client]
    void Update()
    {
        if (hasAuthority)
            CmdMove();


    }

    void FixedUpdate()
    {

        RigidBody.MovePosition(RigidBody.position + movement * movementSpeed * Time.deltaTime);

    }
    [Command]
    private void CmdMove()
    {
        
        RcpMove();

    }
    [ClientRpc]
    private void RcpMove()
    {
        
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        
        
    }
}
