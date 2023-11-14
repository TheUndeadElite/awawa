using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1 : MonoBehaviour
{
    public Rigidbody2D myRigidBody = null;

    public float MovementSpeedPerSecond = 10.0f;
    public float MovementSign = 1.0f;
    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        Vector3 characterVelocity = myRigidBody.velocity;
        characterVelocity.x = 0f;

        //add velocity in character right direction
        characterVelocity += MovementSign * MovementSpeedPerSecond * transform.right.normalized;
        myRigidBody.velocity = characterVelocity;
    }
}
