using UnityEngine;
using System.Collections;
using System;

namespace UnityStandardAssets._2D
{
    public class WallBehaviour: MonoBehaviour
    {
        public Rigidbody2D rb2d;
        public bool hasWallStuck = false;

        [SerializeField] private float wallSlideSpeed;
        [SerializeField] private float maxWallSlideSpeed;
        [SerializeField] private float wallJumpX;
        [SerializeField] private float wallJumpY;

        private PlatformerCharacter2D m_Character;
        private Platformer2DUserControl userControl;

        
        // Use this for initialization
        void Start()
        {
            rb2d = GetComponent<Rigidbody2D>();
            userControl = GetComponent<Platformer2DUserControl>();
            m_Character = GetComponent<PlatformerCharacter2D>();
            
        }

  

        // Update is called once per frame
        void Update()
        {
            if (m_Character.m_Grounded)
            {
                hasWallStuck = false;
            }
        }

        public void FixedUpdate()
        {
            
        }

        public void wallSliding()
        {
            hasWallStuck = true;
            rb2d.gravityScale = 0f;
            rb2d.velocity = new Vector2(0f, -wallSlideSpeed);
            StartCoroutine(Unstick());
            }

        public void WallJump(float h)
        {
            rb2d.AddForce(new Vector2(wallJumpX * Mathf.Sign(h), wallJumpY));
        }

        public IEnumerator Unstick()
        {
            yield return new WaitForSeconds(0.25f);
            userControl.playerState = Platformer2DUserControl.PLAYERSTATE.MOVING;

        }


    }
    }