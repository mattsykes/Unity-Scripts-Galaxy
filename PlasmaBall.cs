using UnityEngine;
using System.Collections;

public class PlasmaBall : MonoBehaviour {


    //Instantiate the object, shoot it towards mouse position. at a constant velocity, when instantiated need to set direction vector2, which is == mouse pos
    //variable for mouse position, need location to instantiate object(Transform), 
    // Use this for initialization



	void Awake () {
        StartCoroutine(DestroyThis());
	}
	

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            //do some stuff to enemy
        }
        else Destroy(gameObject);
    }

    IEnumerator DestroyThis()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }

}
