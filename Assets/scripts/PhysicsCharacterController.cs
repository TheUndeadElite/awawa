using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;

public class PhysicsCharacterController : MonoBehaviour
{
    public GameObject mySmallGroundCheck = null;
    public GameObject myBigGroundCheck = null;

    public SpriteRenderer mySpriteRenderer = null; 
    public List<Sprite> CharacterSprites = new List<Sprite>();
    public int HP = 0;

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
        if (HP <= 0)
        {
            //try to get a reference to sceneloaderscript on this gameobject
            Sceneloader mySceneLoader = gameObject.GetComponent<Sceneloader>();
            //check if we succeded
            if (mySceneLoader != null)
            {
                //change to scene "game over"
                mySceneLoader.LoadScene("Game Over");
            }
        }

        //copy our hp-1 to our new variable
        int HPcopy = HP-1;
        //if hpcopy is less than zero, set it to zero
        if (HPcopy < 0)
        {
            HPcopy = 0;
        }
        //larger or equal to the number of different sprites in charactersprites, set it to number -1
        if (HPcopy >= CharacterSprites.Count)
        {
            HPcopy = CharacterSprites.Count -1;
        }
        if(HPcopy == 0)
        {
            mySmallGroundCheck.SetActive(true);
            myBigGroundCheck.SetActive(false);
        }
        else
        {
            mySmallGroundCheck.SetActive(false);
            myBigGroundCheck.SetActive(true);
        }
        // assign correct sprite to renderer component
        mySpriteRenderer.sprite = CharacterSprites[HPcopy];
        
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

    public void TakeDamage(int aHPValue)
    {
        HP += aHPValue;
    }
}