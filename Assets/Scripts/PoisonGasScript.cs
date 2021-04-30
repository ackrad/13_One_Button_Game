using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonGasScript : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            var playerController = other.GetComponent<Player_Controller>();

            if (!playerController.powerUps["Poison_Immunity"])
            {

                playerController.StartDeath();
            }

        }

    }
}
