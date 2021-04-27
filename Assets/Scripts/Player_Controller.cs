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
    [SerializeField] LayerMask whatIsGrounded;
    [SerializeField] float jumpTimer = 1f;
    private float jumpTimeCounter = 0f;
    //[SerializeField] BoxCollider jumpCollider;
    // Start is called before the first frame update

    Rigidbody rb;
    bool isGrounded = true;
    bool canDoubleJump = true;
    bool isJumping = false;


    Vector3 jump = new Vector3(0f, 1f, 0f);
    // Powerups go here and get set

    Dictionary<string, bool> powerUps = new Dictionary<string, bool>()
        {
            { "Jump",false },
            { "Double_Jump", false },
            {"Swim",false },
            {"DropDown",false }

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
        isGrounded = Physics.CheckSphere(feetpos.position,checkRadius);
    }


    private void Jump() //TODO Make better Jump Control Can be an Upgrade
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded && powerUps["Jump"])
        {
            


            // rb.AddForce(jump * jumpForce, ForceMode.Impulse);

            rb.velocity = Vector3.up * jumpForce;
            isGrounded = false;
            isJumping = true;
            jumpTimeCounter = jumpTimer;
        }

        if(Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector3.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else { isJumping = false; }

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
            canDoubleJump = true;
        }

        
        else if(Input.GetKeyDown(KeyCode.Space) && powerUps["Double_Jump"] && canDoubleJump )  
        {
            Debug.Log("xd");
            rb.velocity = Vector3.up * jumpForce;
            canDoubleJump = false;
        }
    }

  


    public void AcquirePowerUp(PowerUp powerUp)
    {

        powerUps[powerUp.ToString()] = true;

    }
 

    public void StartDeath()
    {
        transform.position = startingLocation.position;
    }












}
