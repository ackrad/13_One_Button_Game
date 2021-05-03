using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicSystem : MonoBehaviour
{


    private void Awake()
    {
        

        MusicSystem[] objs = FindObjectsOfType<MusicSystem>();

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }


        DontDestroyOnLoad(this.gameObject);
    }







}

