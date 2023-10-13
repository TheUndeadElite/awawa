using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class block : MonoBehaviour //optional rename to collision
{
    //x = Width, y = Height
    public Vector2 Dimensions = new Vector2(16.0f, 16.0f);
    public Vector2 LowerLeftCorner = new Vector2();

    public static bool CheckCollision(block aObject1, block aObject2)
    {

        if (aObject1.LowerLeftCorner.x < aObject2.LowerLeftCorner.x + aObject2.Dimensions.x &&
            aObject1.LowerLeftCorner.x + aObject1.Dimensions.x > aObject2.LowerLeftCorner.x &&
            aObject1.LowerLeftCorner.y < aObject2.LowerLeftCorner.y + aObject2.Dimensions.y &&
            aObject1.LowerLeftCorner.y + aObject2.Dimensions.y > aObject2.LowerLeftCorner.y)
        {
            return true;
        }
        return false;
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        LowerLeftCorner = new Vector2(transform.position.x - (Dimensions.x * 0.5f), transform.position.y - (Dimensions.y * 0.5f));
    }
}
