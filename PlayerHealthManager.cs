using UnityEngine;
using System.Collections;
using System;

namespace Galaxy {
    public class PlayerHealthManager : MonoBehaviour {


        public static int playerHealth = 100;
        private Restarter restarter;
        private Collider2D col;
        [SerializeField] private GameObject player;


        public void Start()
        {
            restarter = GetComponent<Restarter>();
            col = player.GetComponent<Collider2D>();
        }

        public static void DoDamageToPlayer(int damage) {
            playerHealth -= damage;
        }

        public void Update()
        {
            if (playerHealth <= 0)
            {
                StartCoroutine(PlayerDeath());//if the player dies, load the level. //need to add death effects and coroutine for restarting
                                                //the level at a check point, with death/particle effects.
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
