using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [SerializeField] float speed = 10f;

    // Start is called before the first frame update
  

    // Update is called once per frame
    void Update()
    {

        transform.position += new Vector3(1f, 0f, 0f) * Time.deltaTime * speed;

    }
}
