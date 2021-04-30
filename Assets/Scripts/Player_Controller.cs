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

    Rigidbody rb;
    bool isGrounded = true;
    bool canDoubleJump = true;
    bool isJumping = false;
    bool isDoubleJumping = false;
    bool hasJumped = false;
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

    private void OnDrawGizmos()
    {
        
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position += new Vector3(1f, 0f, 0f) * Time.deltaTime * speed; // constant right movement

        Jump();


    }



    private void FixedUpdate()
    {

        isGrounded = Physics.CheckSphere(feetpos.position, checkRadius, whatIsGround);
    }


    public void TouchedGround()
    {
        hasJumped = false;
    }

  


    private void Jump() //TODO Make better Jump Control Can be an Upgrade
    {
        BetterJump();

        if (hasJumped)
        {
            BetterDoubleJump();
        }
    }

    private void BetterDoubleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canDoubleJump && !isGrounded && powerUps["Double_Jump"])
        {
           

            rb.velocity = Vector3.up * jumpForce;
            isDoubleJumping = true;
            jumpTimeCounter = jumpTimer;
            canDoubleJump = false;
        }

        if (Input.GetKey(KeyCode.Space) && isDoubleJumping)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector3.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else { isDoubleJumping = false; }

        }

        if (Input.GetKeyUp(KeyCode.Space) && isDoubleJumping)
        {
            isDoubleJumping = false;

        }
    }

    private void BetterJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && powerUps["Jump"])
        {



            // rb.AddForce(jump * jumpForce, ForceMode.Impulse);

            rb.velocity = Vector3.up * jumpForce;
            isGrounded = false;
            isJumping = true;
            jumpTimeCounter = jumpTimer;
            hasJumped = false;
        }

        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector3.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else { isJumping = false; }

        }
        if (Input.GetKeyUp(KeyCode.Space) && !hasJumped)
        {
            isJumping = false;
            canDoubleJump = true;
            hasJumped = true;
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












}
