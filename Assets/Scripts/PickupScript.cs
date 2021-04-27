using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 50f;
    [SerializeField] PowerUp powerUpSlot;
    // Start is called before the first frame update


    private void Update()
    {
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0 ,Space.World); //rotates 50 degrees per second around z axis
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            other.GetComponent<Player_Controller>().AcquirePowerUp(powerUpSlot);

            Destroy(this.gameObject);
            

        }


    }

}
