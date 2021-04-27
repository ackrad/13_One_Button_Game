using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    [SerializeField] Player_Controller player;

    private void PlayerHit()
    {
       
        
            player.StartDeath();

        
    }
}
