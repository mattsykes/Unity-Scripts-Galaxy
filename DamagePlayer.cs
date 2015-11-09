using UnityEngine;
using System.Collections;

namespace Galaxy {
    public class DamagePlayer : MonoBehaviour
    {
        private SmallEnemyPatrol smallEnemyPatrol;
        public int damageToGive; //float for the inspector to tell the object how much damage to give to the player when they collide

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
                print("Hit Player!");
                smallEnemyPatrol.hasHitPlayer = true;
                PlayerHealthManager.DoDamageToPlayer(damageToGive);
            }
        }
    }
}
