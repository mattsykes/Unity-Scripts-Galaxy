using UnityEngine;
using System.Collections;
using System;

public class EnemyHealthManager : MonoBehaviour {


    //references
    public int enemyHealth;
    public int points;

	
	// Update is called once per frame
	void Update () {
	    if(enemyHealth <= 0) //kill enemy
        {
            //play death animation then destroy object( could get rid of collider so doesnt interact?)
            // for flying enemies need a destroyed animation while falling then an explosion on floor? then destroy the object.
            // can access a coroutine where input amount of seconds to wait so can set in the inspector
            // points manager needs to get points update from this point field.
            // Possible need for a coroutine, play animation and set layers to not interact with player, just to interact with ground. then destroy.
            Destroy(gameObject);
        }
	}

    public void doDamage(int damage) //Do Damage to Enemy
    {
        enemyHealth -= damage ;
        //instantiate particle effect for damage
    }
}
