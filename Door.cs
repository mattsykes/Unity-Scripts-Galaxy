using UnityEngine;
using System.Collections;


namespace Galaxy
{
    public class Door : MonoBehaviour
    {

        void OnTriggerStay2D(Collider2D other)
        {
            if (other.tag == "Player" && Input.GetKeyDown(KeyCode.F))
            {
                //move the door to a position above. (not sure if to make the doors open by button pressing or automatic.
                print("Door Up!");
            }

        }


    }
}
