using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFireScript : MonoBehaviour
{
    [SerializeField] Bullet bulletPreFab;
    [SerializeField] Transform firingPos;
    [SerializeField] Transform player;
    [SerializeField] float secondsBetweenShots = 5f;
    [SerializeField] float firingDistance = 20f;



    private bool isFiring = false;

    // Start is called before the first frame update

    private void Start()
    {
        StartCoroutine(FireCoroutine());
    }

    private void Update()
    {


    }



  


    IEnumerator FireCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(secondsBetweenShots);
            Instantiate(bulletPreFab, firingPos.position, Quaternion.Euler(new Vector3(0, 0, 90)));
        }

    }
}
