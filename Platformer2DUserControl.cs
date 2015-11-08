using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof(PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        public enum PLAYERSTATE //Player States
        {
            MOVING = 1,
            WALLSLIDING,
            CROUCHING,
        }

        //references
        private PlatformerCharacter2D m_Character;
        private WallBehaviour m_wallBehaviour;
        private SwordAttack m_swordAttack;
        private bool m_Jump;
        public PLAYERSTATE playerState;
        public bool hasStandardSwordAttacke = false; //Bools used for timing the attacks
        public bool hasStandardSwordAttackedAbove = false;
        public bool hasStandardSwordAttackedBelow = false;

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
            m_wallBehaviour = GetComponent<WallBehaviour>();
        }

        private void Start()
        {
            m_swordAttack = FindObjectOfType<SwordAttack>();
        }

        private void Update()
        {
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            //float v = CrossPlatformInputManager.GetAxis("Vertical");
            if (m_Character.m_Grounded) //set player to moving state if grounded
                playerState = PLAYERSTATE.MOVING;

            if (m_Character.m_Walled && !m_Character.m_Grounded && !m_wallBehaviour.hasWallStuck) //using states to control wallbehaviour, gives more control
                playerState = PLAYERSTATE.WALLSLIDING;                                            //because of the friction parameter making player sticks to
                                                                                                  //walls if holding the direction of the wall
                                                                                                  
            if (playerState == PLAYERSTATE.WALLSLIDING && Input.GetKeyDown(KeyCode.Space))      //if the player is holding the oposite direction to the wall                                                                                                     
            {                                                                                   //the walljumps in the oposite direction
                print("Jump was pressed");
                playerState = PLAYERSTATE.MOVING;
                m_wallBehaviour.WallJump(h);
            }

            if (!m_Jump)
            {

                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }

            if (playerState == PLAYERSTATE.MOVING && Input.GetButtonDown("Fire2"))
            {
                m_Character.Shoot();
            }

            if (playerState == PLAYERSTATE.WALLSLIDING && Input.GetButtonDown("Fire2")) //shoots in the oposite direction if on a wall
            {
                m_Character.WallShoot();
            }

            //sets the direction of attacks depending on player state and button pressed
            if (playerState == PLAYERSTATE.MOVING && Input.GetButtonDown("Fire1") &&
                hasStandardSwordAttacke == false && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S)
                && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || h <= 1))
            {
                m_swordAttack.StandardSwordAttack();
            }
            if (playerState == PLAYERSTATE.MOVING && Input.GetButtonDown("Fire1") &&
                hasStandardSwordAttackedAbove == false && Input.GetKey(KeyCode.W))
            {
                m_swordAttack.SwordAttackAbove();
            }
            if (playerState == PLAYERSTATE.MOVING && Input.GetButtonDown("Fire1") && Input.GetKey(KeyCode.S) && !m_Character.m_Grounded)
            {
                m_swordAttack.SwordAttackBelow();
            }
        }


        private void FixedUpdate()
        {
            switch (playerState)
            {
                case PLAYERSTATE.MOVING: //sets up player inputs and physics for the moving state
                    print("Moving");
                    GetComponent<Rigidbody2D>().gravityScale = 2f;
                    // Read the inputs.
                    bool crouch = Input.GetKey(KeyCode.LeftControl);
                    float h = CrossPlatformInputManager.GetAxis("Horizontal");
                    // Pass all parameters to the character control script.
                    m_Character.Move(h, crouch, m_Jump);
                    m_Jump = false;
                    break;


                case PLAYERSTATE.WALLSLIDING: //sets player state wallsliding and executes the behaviour in the wallbehaviour script
                    print("WALLSLIDING");
                    m_wallBehaviour.wallSliding();
                    break;

            }

        }


    }

}