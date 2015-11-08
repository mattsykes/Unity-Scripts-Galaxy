using UnityEngine;
using System.Collections;

public class DamagePlayer : MonoBehaviour {


	void Update () {
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            print("Hit Player!");
            PlayerHealthManager.DoDamageToPlayer(50);
        }
    }

}
