using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactercontroller: MonoBehaviour
{
    public float MovementSpeed = 100.0f;
    void Update()
    {
        
        //Up
        if (Input.GetKey(KeyCode.W)) 
        { 
            Vector3 characterposition = transform.position;
            characterposition.y += MovementSpeed * Time.deltaTime;
            transform.position = characterposition;
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
