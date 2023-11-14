using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flagpole : MonoBehaviour
{
    public Sceneloader mySceneLoader = null;
    public string NextScene = "MainMenu";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        mySceneLoader.LoadScene(NextScene);
        var PlayerScript = collision.gameObject.GetComponent<PhysicsCharacterController>();
        if (PlayerScript != null)
        {
            mySceneLoader.LoadScene(NextScene);
        }
    }
}
