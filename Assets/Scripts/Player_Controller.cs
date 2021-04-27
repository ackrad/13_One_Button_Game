using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float jumpForce = 2f;
    [SerializeField] Transform startingLocation;
    //[SerializeField] BoxCollider jumpCollider;
    // Start is called before the first frame update

    Rigidbody rb;
    public bool isGrounded = true;

    // Powerups go here and get set

    Dictionary<string, bool> powerUps = new Dictionary<string, bool>()
        {
            { "Jump",false },
            { "Double_Jump", false },
            {"Swim",false },
            {"DropDown",false }

        };



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



    private void OnCollisionEnter(Collision collision)
    {
        isGrounded =true;
    }
    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded && powerUps["Jump"])
        {
            Vector3 jump = new Vector3(0f, 1f, 0f);
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    public void ChangeIsGrounded(bool changeGrounded)
    {

        isGrounded = changeGrounded;


    }


    public void AcquirePowerUp(PowerUp powerUp)
    {
        Debug.Log(powerUp.ToString());

        powerUps[powerUp.ToString()] = true;

    }
 

    public void StartDeath()
    {
        transform.position = startingLocation.position;
    }

}
