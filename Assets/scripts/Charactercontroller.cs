using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

//TODO: make gravity slower when jumping then increasing speed while falling.
public class charactercontroller: MonoBehaviour
{
    public float MovementSpeed = 100.0f;

    //gravity
    public float Gravityspeed = 50.0f;
    public float GroundLevel = 0.0f;
    void Update()
    {
        //gravity
        Vector3 gravityposition = transform.position;
        gravityposition.y -= Gravityspeed * Time.deltaTime;
        if(gravityposition.y < GroundLevel) {gravityposition.y = GroundLevel;}
        transform.position = gravityposition;


        //Up
        if (Input.GetKey(KeyCode.W)) 
        { 
            Vector3 characterposition = transform.position; //copy character position
            characterposition.y += MovementSpeed * Time.deltaTime;
            transform.position = characterposition; // paste new position
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


    }
}
