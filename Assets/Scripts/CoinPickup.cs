using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{

    [SerializeField] float rotateSpeed = 50f;
    GameSystemController gameSystem;
    // Start is called before the first frame update


    private void Start()
    {
        gameSystem = FindObjectOfType<GameSystemController>();
    }
    private void Update()
    {
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0, Space.World); //rotates 50 degrees per second around z axis
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            gameSystem.IncreaseStarAmount();

            Destroy(this.gameObject);


        }


    }
}
