using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.RestService;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public Playerdata Savefile = null;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var PlayerScript = collision.gameObject.GetComponent<PhysicsCharacterController>();
        if (PlayerScript != null)
        {
            Savefile.PlayerPoints += 1;
            GameObject.Destroy(gameObject);
        }
    }
}
