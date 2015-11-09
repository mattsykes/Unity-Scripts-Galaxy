using UnityEngine;
using System.Collections;
using System;

namespace Galaxy {
    public class PlayerHealthManager : MonoBehaviour {

        //references
        public static int playerHealth = 100;
        private Restarter restarter;
        private Collider2D col;
        [SerializeField] private GameObject player;
        public static bool isInvulnerable = false;

        
        public void Start()
        {
            restarter = GetComponent<Restarter>();
            col = player.GetComponent<Collider2D>();
        }

        public void DoDamageToPlayer(int damage) {  //method for doing damage to the player.
            if(damage < playerHealth)                //if player has been hit and is not dead
            {
                StartCoroutine(PlayerInvulnerable());
            }
            playerHealth -= damage;
        }

        private IEnumerator PlayerInvulnerable() //Sets player Invulnerable after taking damage
        {
            isInvulnerable = true;
            yield return new WaitForSeconds(1f);
            isInvulnerable = false;
        }

        public void Update()
        {
            if (playerHealth <= 0)
            {
                StartCoroutine(PlayerDeath());//if the player dies, load the level. //need to add death effects and coroutine for restarting
                                                //the level at a check point, with death/particle effects.
            }

            if (isInvulnerable)
            {
                player.gameObject.tag = "PlayerInvulnerable"; //changing tags because still want to be able to interact with enviroment but not take any damage.
            }
            else
            {
                player.gameObject.tag = "Player";
            }
        }

        private IEnumerator PlayerDeath()
        {
            
            player.gameObject.SetActive(false);
            playerHealth = 100;
            //play animation, exit time, maybe instantiate an object with the animation? not sure yet
            yield return new WaitForSeconds(1f /*needs to be length of animation*/);

            Application.LoadLevel(Application.loadedLevelName);
        }

        
    }
}
