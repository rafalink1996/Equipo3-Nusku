﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toFishing : MonoBehaviour
{

    public SpriteRenderer icon;
    bool canFish;
    public GameObject cantFish;
    // Start is called before the first frame update
    void Start()
    {
        icon = GameObject.Find("Sel/Interact_Icon").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStats.stats.hasFishingRod){
            Destroy(cantFish);
        }
        if (Input.GetButtonDown("Interact") && canFish && GameStats.stats.fishes < 3){
            SceneManager.LoadScene("Fishing");
            GameStats.stats.position = new Vector2(0.41f, -0.12f);
            GameStats.stats.selDirectionX = 1;
            GameStats.stats.selDirectionY = -1;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameStats.stats.fishes < 3 && GameStats.stats.hasFishingRod)
        {
            icon.enabled = true;
            canFish = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        icon.enabled = false;
        canFish = false;
    }
}
