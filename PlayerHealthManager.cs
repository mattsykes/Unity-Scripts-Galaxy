using UnityEngine;
using System.Collections;

public class PlayerHealthManager : MonoBehaviour {

    public static int playerHealth = 100;

    public static void DoDamageToPlayer(int damage){
        playerHealth -= damage;
        }
	
	
}
