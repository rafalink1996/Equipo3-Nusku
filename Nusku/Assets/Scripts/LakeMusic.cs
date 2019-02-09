using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LakeMusic : MonoBehaviour
{
    public static LakeMusic lMusic;
    // Use this for initialization
    void Awake()
    {
        if (lMusic == null)
        {
            DontDestroyOnLoad(gameObject);
            lMusic = this;
        }
        else if (lMusic != this)
        {
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name != "Lake" && SceneManager.GetActiveScene().name != "Fishing")
        {
            Destroy(gameObject);
        }
    }
}
