using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaypointTest : MonoBehaviour {


    //States for enemy to occupy.
    public enum ENEMYSTATE
    {
        PATROL = 1,
        DIVING,
        MOVEBACK
    }

    //references
    public GameObject player; 
    public float speed; // speed of enemy moving from waypoints or to the player
    public bool playerInRange = false;
    private Vector3 spawnPosition;
    public GameObject enemy;
    private Animator anim;
    public List<Vector2> waypoints;
    private int i = 0; //used to interate through waypoints


    ENEMYSTATE enemyState = ENEMYSTATE.PATROL;//initializes the enemyState object of enum type ENEMYSTATE
    private bool hasReturned = false; //bool to tell when the enemy has returned to its spawn location after diving the player

    public void Awake()
    {
        spawnPosition = transform.position; //gets the spawn location as soon as the object is loaded in the scene
        anim = GetComponentInChildren<Animator>(); //retrieves the animator from the graphics object tied to the enemy object
    }


    void Update()
    {

        switch (enemyState)
        {
            case ENEMYSTATE.DIVING: //Diving state of when the player is in range
                if (playerInRange)
                {
                    hasReturned = false;
                    anim.SetBool("IsDiving", true);
                    enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, player.transform.position, speed * 3 * Time.deltaTime);
                }
                break;

            case ENEMYSTATE.PATROL: //When the player is out of range, the enemy patrols waypoints
                {
                    anim.SetBool("IsDiving", false);

                    if (!hasReturned)
                    {// need to find tune values and get rid of magic numbers.
                        Debug.Log("GO!");
                        transform.position = Vector2.MoveTowards(transform.position, spawnPosition, speed * 10  * Time.deltaTime);
                        hasReturned = true;
                    }
                    if (hasReturned)
                    {
                        transform.position = Vector2.MoveTowards(transform.position, waypoints[i], speed * 2* Time.deltaTime);
                        if (transform.position.x == waypoints[i].x && transform.position.y == waypoints[i].y) //iterates through the waypoints
                        {
                            Debug.Log("Next Waypoint");
                            i++;
                            if (i > 7)
                            {
                                i = 0;
                            }
                        }
                    }
                }
                break;
        }


    }

    void OnTriggerEnter2D(Collider2D other) //if the player is in range, attack.
    {
        if (other.tag == "Player")
        {
            playerInRange = true;
            enemyState = ENEMYSTATE.DIVING;
        }
    }

    void OnTriggerExit2D(Collider2D other) //if out of range patrol
    {
        if (other.tag == "Player")
        {
            playerInRange = false;
            enemyState = ENEMYSTATE.PATROL;
        }

    }


}
