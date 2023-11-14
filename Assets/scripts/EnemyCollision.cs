using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public enemy1 myEnemyScript = null;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //copy enemy scale
        Vector3 enemyScale = myEnemyScript.transform.localScale;
        //multiply x scale by -1
        enemyScale.x = -enemyScale.x;
        //write scale back to transform
        myEnemyScript.transform.localScale = enemyScale;
        //multiply enemy movement direction by -1 so -1 = 1/1 = -1
        myEnemyScript.MovementSign = -1;
        //myEnemyScript.transform.localscale = new Vector3(-myEnemyScript.transform.localScale.x, myEnemyScript.transform.localScale.y, -myEnemyScript.transform.localScale.z);
    }
}
