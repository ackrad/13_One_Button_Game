using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win_Script : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {

            FindObjectOfType<GameSystemController>().WinGame();
        }
    }
}
