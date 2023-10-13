using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public enum characterstate // a enumerated list of charafcter states
{
    Grounded = 0, //ground
    Airborne = 1, //airborne
    Jumping = 2, // is currently jumping in the air
    Total
    
}

//TODO: make gravity pick up speed the longer you're in the air. change gravity speed to 130 and jump height maxa to 100.
public class charactercontroller: MonoBehaviour
{
    public characterstate Jumpstate = characterstate.Airborne; // Is our character on the ground or in the air?

    
    //movement
    public float MovementSpeed = 100.0f;

    //gravity
    public float Gravityspeed = 50.0f; // should be 130
    public float GroundLevel = 0.0f;

    //Jump
    public float JumpSpeedFactor = 3.0f; // how much faster is the jump than the movespeed
    public float JumpMaxHeight = 150.0f; //should be 100
    private float JumpHeightDelta = 0.0f;

    void Update()
    {
        bool ismoving = false; //tells us if character is moving

        if(transform.position.y <= GroundLevel) // check if character is lower than or equal to the ground
        {
                Vector3 characterposition = transform.position;
            characterposition.y = GroundLevel;
            transform.position = characterposition;
            Jumpstate = characterstate.Grounded;
        }
        //Up
        if (Input.GetKey(KeyCode.W) && Jumpstate == characterstate.Grounded) 
        {
            //Jump
            Jumpstate = characterstate.Jumping;
        }
        if(Jumpstate == characterstate.Jumping)
        {
            Vector3 characterposition = transform.position;
            float currentposition = characterposition.y;
            float totalJumpMovement = MovementSpeed * JumpSpeedFactor * Time.deltaTime;
            characterposition.y += totalJumpMovement;
            transform.position = characterposition;
            JumpHeightDelta += totalJumpMovement;
            if(JumpHeightDelta >= JumpMaxHeight)
            {
                Jumpstate = characterstate.Airborne;
                JumpHeightDelta = 0.0f;
            }
        }
        //Left
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 characterposition = transform.position;
            characterposition.x -= MovementSpeed * Time.deltaTime;
            transform.position = characterposition;
        }
        //Down
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 characterposition = transform.position;
            characterposition.y -= MovementSpeed * Time.deltaTime;
            transform.position = characterposition;
        }
        //Right
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 characterposition = transform.position;
            characterposition.x += MovementSpeed * Time.deltaTime;
            transform.position = characterposition;
        }

        if (ismoving == false) //checks if ismoving is false and adds gravity if its false
        {
            Vector3 gravityposition = transform.position;
            gravityposition.y -= Gravityspeed * Time.deltaTime;
            if (gravityposition.y < GroundLevel) { gravityposition.y = GroundLevel; }
            transform.position = gravityposition;
        }
    }
}
