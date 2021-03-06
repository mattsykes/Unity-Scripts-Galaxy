﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

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
    public bool hasHitPlayer;

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
                    if (hasHitPlayer)
                    {
                        GetComponent<Collider2D>().enabled = false;
                        enemyState = ENEMYSTATE.PATROL;
                        StartCoroutine(DivePlayerAgain());
                    }
                }
                break;

            case ENEMYSTATE.PATROL: //move enemy to spawn position if player out of range 
                {
                    
                    enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, spawnPosition, speed * Time.deltaTime);
                }
                break;
        }


    }

    private IEnumerator DivePlayerAgain()
    {
        yield return new WaitForSeconds(2);
        hasHitPlayer = false;
        GetComponent<Collider2D>().enabled = true;
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
