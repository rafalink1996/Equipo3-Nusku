using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmirGone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameStats.stats.hasGlove)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
