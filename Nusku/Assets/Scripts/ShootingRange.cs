using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingRange : MonoBehaviour
{


    public Slider slider;
    public static float score;
    bool right = true;
    public float speed;
    float aim;
    int shots = 5;
    bool shot;
    public bool shooting;
    public Vector2 target;
    public GameObject sceneChanger;
    AudioSource sound;
    public AudioClip shootSound;
    int minValue = 48;
    int maxValue = 52;


    // Use this for initialization
    void Start()
    {
        sound = GetComponent<AudioSource>();
        aim = speed;
        slider.value = 0;
        score = 0;
        if (GameStats.stats.dartsTries >= 12)
        {
            minValue = 43;
            maxValue = 57;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        print("shots = " + shots);
        if (right)
        {
            slider.value += aim;
        }
        if (slider.value >= 100)
        {
            right = false;
        }
        if (!right)
        {
            slider.value -= aim;
        }
        if (slider.value <= 0)
        {
            right = true;
        }
        if (Input.GetButtonDown("Fire1") && shots > 0 && !shot && !shooting)
        {
            Shoot();
        }
        if (shot)
        {
            if (slider.value > minValue && slider.value < maxValue)
            {
                score = score + 1000;
                target = new Vector2(4.817f, 0.637f);
            }
            if (slider.value >= 40 && slider.value <= minValue || slider.value >= maxValue && slider.value <= 60)
            {
                score = score + 800;
                target = new Vector2(Random.Range(4.62f, 5.13f), Random.Range(0.31f, 1.03f));
            }
            if (slider.value >= 30 && slider.value < 40 || slider.value > 60 && slider.value <= 70)
            {
                score = score + 600;
                target = new Vector2(Random.Range(4.62f, 5.13f), Random.Range(0.31f, 1.03f));
            }
            if (slider.value >= 20 && slider.value < 30 || slider.value > 70 && slider.value <= 80)
            {
                score = score + 400;
                target = new Vector2(Random.Range(4.62f, 5.13f), Random.Range(0.31f, 1.03f));
            }
            if (slider.value >= 10 && slider.value < 20 || slider.value > 80 && slider.value <= 90)
            {
                score = score + 200;
                target = new Vector2(Random.Range(4.62f, 5.13f), Random.Range(0.31f, 1.03f));
            }
            if (slider.value >= 5 && slider.value < 10 || slider.value > 90 && slider.value <= 96)
            {
                score = score + 100;
                target = new Vector2(Random.Range(4.62f, 5.13f), Random.Range(0.31f, 1.03f));
            }
            if (slider.value < 5 || slider.value > 96)
            {
                target = new Vector2(Random.Range(4.325f, 4.425f), Random.Range(1.065f, 1.165f));
            }
            shot = false;
        }
        if (shots == 0)
        {
            sceneChanger.transform.position = Vector2.MoveTowards(sceneChanger.transform.position, transform.position, 0.05f * Time.deltaTime);
            if (score > Leaderboard.scoreRox){
                GameStats.stats.hasWonDarts = true;
            }
        }
    }
    public void Shoot()
    {

        aim = 0;
        shot = true;
        shooting = true;
        shots = shots - 1;
        sound.Stop();
        sound.PlayOneShot(shootSound);
        if (shots > 0)
        {
            Invoke("Reload", 3);
        }

    }
    void Reload()
    {
        slider.value = Random.Range(0, 100f);
        aim = speed;
        shooting = false;
        GameObject dart = GameObject.Instantiate(Resources.Load("Prefabs/Dart") as GameObject);
        dart.transform.position = new Vector2(2.512f, -1.123f);
        sound.Play();
    }
}
