using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingRange : MonoBehaviour
{


    public Slider slider;
    public float score;
    bool right = true;
    public float speed;
    float aim;
    int shots = 5;
    bool shot;
    public bool shooting;
    public Vector2 target;
    // Use this for initialization
    void Start()
    {
        aim = speed;
        slider.value = 0;

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
            if (slider.value >= 49 && slider.value <= 51)
            {
                score = score + 1000;
                target = new Vector2(4.817f, 0.637f);
            }
            if (slider.value >= 40 && slider.value <= 48 || slider.value >= 52 && slider.value <= 60)
            {
                score = score + 800;
                target = new Vector2(Random.Range(4.62f, 5.13f), Random.Range(0.31f, 1.03f));
            }
            if (slider.value >= 30 && slider.value <= 39 || slider.value >= 61 && slider.value <= 70)
            {
                score = score + 600;
                target = new Vector2(Random.Range(4.62f, 5.13f), Random.Range(0.31f, 1.03f));
            }
            if (slider.value >= 20 && slider.value <= 29 || slider.value >= 71 && slider.value <= 80)
            {
                score = score + 400;
                target = new Vector2(Random.Range(4.62f, 5.13f), Random.Range(0.31f, 1.03f));
            }
            if (slider.value >= 10 && slider.value <= 19 || slider.value >= 81 && slider.value <= 90)
            {
                score = score + 200;
                target = new Vector2(Random.Range(4.62f, 5.13f), Random.Range(0.31f, 1.03f));
            }
            if (slider.value >= 5 && slider.value <= 9 || slider.value >= 91 && slider.value <= 96)
            {
                score = score + 100;
                target = new Vector2(Random.Range(4.62f, 5.13f), Random.Range(0.31f, 1.03f));
            }
            if (slider.value <= 4 || slider.value >= 97)
            {
                target = new Vector2(Random.Range(4.325f, 4.425f), Random.Range(1.065f, 1.165f));
            }
            shot = false;
        }
    }
    public void Shoot()
    {

        aim = 0;
        shot = true;
        shooting = true;
        shots = shots - 1;
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
    }
}
