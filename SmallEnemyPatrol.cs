using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SmallEnemyPatrol : MonoBehaviour {

    public enum ENEMYSTATE //states for flying enemy behaviours.
    {
        PATROL = 1,
        DIVING
    }

    //references
    public GameObject player;
    public float speed;
    public bool playerInRange = false;
    private Vector2 spawnPosition;
    public GameObject enemy;
    private Animator anim;

    ENEMYSTATE enemyState = ENEMYSTATE.PATROL;


    public void Awake()
    {
        spawnPosition = transform.position; //sets the spawn point for enemy to move back to when changing states.
    }
    

	void Update () {

        switch (enemyState)
        {
            case ENEMYSTATE.DIVING: //move enemy to player if in range
                if (playerInRange)
                {
                    enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, player.transform.position, speed * 2 * Time.deltaTime);
                }
                break;

            case ENEMYSTATE.PATROL: //move enemy to spawn position if player out of range 
                {
                    
                    enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, spawnPosition, speed * Time.deltaTime);
                }
                break;
        }


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerInRange = true;
            enemyState = ENEMYSTATE.DIVING;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerInRange = false;
            enemyState = ENEMYSTATE.PATROL;
        }

    }


}
