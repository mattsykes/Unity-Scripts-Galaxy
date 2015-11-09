using UnityEngine;
using System.Collections;
using System;

namespace Galaxy {
    public class DamagePlayer : MonoBehaviour
    {
        private SmallEnemyPatrol smallEnemyPatrol;
        private PlayerHealthManager healthManager;
        [SerializeField]  private int damageToGive; //float for the inspector to tell the object how much damage to give to the player when they collide
        [SerializeField]  private GameObject player;

        void Start()
        {
            smallEnemyPatrol = GetComponentInChildren<SmallEnemyPatrol>();
            healthManager = FindObjectOfType<PlayerHealthManager>(); 
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
                healthManager.DoDamageToPlayer(damageToGive);
            }
        }

    }
}
