using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{

    [SerializeField] PowerUp powerUpSlot;
    // Start is called before the first frame update
  

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            other.GetComponent<Player_Controller>().AcquirePowerUp(powerUpSlot);
            
            

        }


    }

}
