using UnityEngine;
using System.Collections;
using System;

namespace UnityStandardAssets._2D
{
    public class SwordAttack : MonoBehaviour
    {

        public GameObject swordHitBox;
        public GameObject swordHitBoxAbove;
        public GameObject swordHitBoxBelow;
        private bool hasAttacked;
        private bool hasAttackedAbove;
        private Platformer2DUserControl m_Control;


        private void Start()
        {
            m_Control = GetComponent<Platformer2DUserControl>();
        }


        public void StandardSwordAttack()
        {
            Debug.Log("SwordAttackStandard!");
            swordHitBox.SetActive(true);
            m_Control.hasStandardSwordAttacke = true;
            StartCoroutine(disableMe(0.15f, swordHitBox));
            //set animation <= 0.15seconds.
        }

        private IEnumerator disableMe(float i, GameObject swordHitBox)
        {
            yield return new WaitForSeconds(i);
            swordHitBox.SetActive(false);
            m_Control.hasStandardSwordAttackedAbove = false;
            m_Control.hasStandardSwordAttacke = false;
            m_Control.hasStandardSwordAttackedBelow = false;
        }

        public void SwordAttackAbove()
        {
            Debug.Log("SwordAttackAbove!");
            swordHitBoxAbove.SetActive(true);
            m_Control.hasStandardSwordAttackedAbove = true;
            StartCoroutine(disableMe(0.5f, swordHitBoxAbove));
        }

        public void SwordAttackBelow()
        {
            Debug.Log("SwordAttackBelow!");
            swordHitBoxBelow.SetActive(true);
            m_Control.hasStandardSwordAttackedAbove = true;
            StartCoroutine(disableMe(0.5f, swordHitBoxBelow));
        }
    }
}
