using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingRange : MonoBehaviour
{


    public Slider slider;
    bool right = true;
    public float speed;
    float aim;
    int shots = 3;
    bool shot;
    bool shooting;
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
                print("1000");
            }
            if (slider.value >= 40 && slider.value <= 48 || slider.value >= 52 && slider.value <= 60)
            {
                print("800");
            }
            if (slider.value >= 30 && slider.value <= 39 || slider.value >= 61 && slider.value <= 70)
            {
                print("600");
            }
            if (slider.value >= 20 && slider.value <= 29 || slider.value >= 71 && slider.value <= 80)
            {
                print("400");
            }
            if (slider.value >= 10 && slider.value <= 19 || slider.value >= 81 && slider.value <= 90)
            {
                print("200");
            }
            if (slider.value >= 5 && slider.value <= 9 || slider.value >= 91 && slider.value <= 96)
            {
                print("100");
            }
            if (slider.value <= 4 || slider.value >= 97)
            {
                print("0");
            }
            shot = false;
        }
    }
    void Shoot()
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
        slider.value = 0;
        aim = speed;
        shooting = false;
    }
}
