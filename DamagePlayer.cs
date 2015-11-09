using UnityEngine;
using System.Collections;

namespace Galaxy {
    public class DamagePlayer : MonoBehaviour
    {
        private SmallEnemyPatrol smallEnemyPatrol;
        [SerializeField]  private int damageToGive; //float for the inspector to tell the object how much damage to give to the player when they collide
        [SerializeField]  private GameObject player;

        void Start()
        {
            smallEnemyPatrol = GetComponentInChildren<SmallEnemyPatrol>();
        }

        void Update()
        {
        }

        void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.tag == "Player")
            {
                print(col.relativeVelocity);
                player.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 400);
                player.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 200);
                //set the animation on the player, 
                //player.gameObject.GetComponent<Animator>().SetBool("DroneAttack", true);
                print("Hit Player!");
                smallEnemyPatrol.hasHitPlayer = true;
                PlayerHealthManager.DoDamageToPlayer(damageToGive);
            }
        }
    }
}
