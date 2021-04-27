using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        transform.position += new Vector3(-1f, 0f, 0f) * Time.deltaTime * bulletSpeed; // constant left movement

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {

            other.GetComponent<Player_Controller>().StartDeath();
        }

        else
        {

            Destroy(gameObject);
        }
    }


   

}
