using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    
    Player_Controller player;

    private void Start()
    {
        player = FindObjectOfType<Player_Controller>();

    }

    private void PlayerHit()
    {
       
        
            player.StartDeath();

        
    }
}
