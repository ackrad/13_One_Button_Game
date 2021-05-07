using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float jumpForce = 2f;
    [SerializeField] Transform startingLocation;
    [SerializeField] Transform feetpos;
    [SerializeField] float checkRadius;
    [SerializeField] LayerMask whatIsGround;
    [SerializeField] float jumpTimer = 1f;
    [SerializeField] GameSystemController gameSystemController;
    private float jumpTimeCounter = 0f;
    //[SerializeField] BoxCollider jumpCollider;
    // Start is called before the first frame update

        // TODO Turn bools down here into game states.
    Rigidbody rb;
    Animation_Controller anim_Controller;
    bool isGrounded = true;
   // bool canDoubleJump = true;
   // bool isJumping = false;
    //bool isDoubleJumping = false;
   // bool hasJumped = false;
   // bool isFalling = false;
    //bool hasDoubleJumped = false;

    private playerState currentState;
    private enum playerState
    {
        idle,
        isJumping,
        hasJumped,
        canDoubleJump,
        isDoubleJumping,
        hasDoubleJumped,
        isFalling

    }

    // GameSystem
    GameSystemController gameSystem;
    
    List<string> powerUpsToAcquire = new List<string>();


    Vector3 jump = new Vector3(0f, 1f, 0f);
    // Powerups go here and get set


    public Dictionary<string, bool> powerUps = new Dictionary<string, bool>()
        {
            { "Jump",false },
            { "Double_Jump", false },
            {"Swim",false },
            {"DropDown",false },
        {"Poison_Immunity", false }

        };

    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameSystem = FindObjectOfType<GameSystemController>();
        anim_Controller = GetComponent<Animation_Controller>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameSystem.isPaused) return;
        

        if (currentState != playerState.isFalling)
        {
            transform.position += new Vector3(1f, 0f, 0f) * Time.deltaTime * speed; // constant right movement
        }

       /* else if (currentState == playerState.isFalling)
        {
            transform.position += new Vector3(0f, -1f, 0f) * Time.deltaTime * speed; // constant right movement
        } */
        Jump();

        DropDownAction();

    }

    private void DropDownAction()
    {


        if (Input.GetKeyDown(KeyCode.Space) && currentState== playerState.hasDoubleJumped && !isGrounded && powerUps["DropDown"])
        {

            currentState = playerState.isFalling;

        }
    }

    private void FixedUpdate()
    {

        isGrounded = Physics.CheckSphere(feetpos.position, checkRadius, whatIsGround);
    }


    public void TouchedGround()
    {

        currentState = playerState.idle;
    }

  


    private void Jump() //TODO Make better Jump Control Can be an Upgrade
    {
        BetterJump();

        if (currentState == playerState.canDoubleJump || currentState == playerState.isDoubleJumping || (!isGrounded && currentState == playerState.idle))
        {
            BetterDoubleJump();
        }
    }

    private void BetterDoubleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) &&  !isGrounded && powerUps["Double_Jump"])
        {
            anim_Controller.TriggerJumpAnimation();

            rb.velocity = Vector3.up * jumpForce;
            currentState = playerState.isDoubleJumping;
            
            jumpTimeCounter = jumpTimer;
                    }

        if (Input.GetKey(KeyCode.Space) && currentState == playerState.isDoubleJumping)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector3.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else { 
                currentState = playerState.hasDoubleJumped;
            }

        }

        if (Input.GetKeyUp(KeyCode.Space) && currentState == playerState.isDoubleJumping)
        {
            currentState = playerState.hasDoubleJumped; 
        }
    }

    private void BetterJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && powerUps["Jump"])
        {

            anim_Controller.TriggerJumpAnimation();



            rb.velocity = Vector3.up * jumpForce;
            currentState = playerState.isJumping;

            jumpTimeCounter = jumpTimer;
            
        }

        if (Input.GetKey(KeyCode.Space) && currentState == playerState.isJumping)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector3.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else { currentState = playerState.canDoubleJump; }

        }
        if (Input.GetKeyUp(KeyCode.Space) && currentState == playerState.isJumping)
        {
            currentState = playerState.canDoubleJump;
        }
    }



    public void AcquirePowerUp(PowerUp powerUp)
    {

       // powerUps[powerUp.ToString()] = true; // TODO delete this

        powerUpsToAcquire.Add(powerUp.ToString());

    }
 

    public void StartDeath()
    {
        transform.position = startingLocation.position;

        foreach(string powerUp in powerUpsToAcquire)
        {
            powerUps[powerUp] = true;

        }

        powerUpsToAcquire.Clear();

    }






    public void MoveLeft()
    {

        speed = -1 * speed;
    }





}
