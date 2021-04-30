using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetCollisionScript : MonoBehaviour
{
    [SerializeField] Player_Controller playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponentInParent<Player_Controller>();
    }
    private void OnTriggerEnter(Collider other)
    {
        playerController.TouchedGround();
    }

 
}
