using UnityEngine;
using System.Collections;

public class DamageEnemy : MonoBehaviour {



        public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            other.GetComponent<EnemyHealthManager>().doDamage(5);
        }
    }
}
