using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class PhysicsCharacterController : MonoBehaviour
{
    //Refrence to rigidbody on same object
    public Rigidbody2D myRigidBody = null;

    public characterstate JumpingState = characterstate.Airborne;
    //Is Our character on the ground or in the air?

    //Gravity
    public float GravityPerSecond = 160.0f; //Falling Speed
    public float GroundLevel = 0.0f; //Ground Value

    //Jump
    public float JumpSpeedFactor = 3.0f; //How much faster is the jump than the movespeed?
    public float JumpMaxHeight = 150.0f;
    [SerializeField]
    private float JumpHeightDelta = 0.0f;
    private float JumpStartingY = 0.0f;
    //Movement
    public float MovementSpeedPerSecond = 10.0f; //Movement Speed


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && JumpingState == characterstate.Grounded)
        {
            JumpingState = characterstate.Jumping; //Set character to jumping
            JumpHeightDelta = 0.0f; //Restart Counting Jumpdistance
            JumpStartingY = transform.position.y;
        }
    }


    void FixedUpdate()
    {
        Vector3 characterVelocity = myRigidBody.velocity;
        characterVelocity.x = 0.0f;

        if(JumpingState == characterstate.Airborne)
        {
            if (characterVelocity.x > -1.0f)
            {
                JumpingState = characterstate.Airborne;
            }
        }
      

        if (JumpingState == characterstate.Jumping)
        {

            float jumpMovement = MovementSpeedPerSecond * JumpSpeedFactor;
            characterVelocity.y = jumpMovement;

            JumpHeightDelta += jumpMovement * Time.deltaTime;

            if (JumpHeightDelta >= JumpMaxHeight)
            {
                JumpingState = characterstate.Airborne;
                JumpHeightDelta = 0.0f;
                characterVelocity.y = 0.0f;
            }
        }

        //Left
        if (Input.GetKey(KeyCode.A))
        {
            characterVelocity.x -= MovementSpeedPerSecond;
        }
        //Right
        if (Input.GetKey(KeyCode.D))
        {
            characterVelocity.x += MovementSpeedPerSecond;
        }
        myRigidBody.velocity = characterVelocity;

    }
}