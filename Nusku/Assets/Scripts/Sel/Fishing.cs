using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fishing : MonoBehaviour {


    Animator anim; //Podría ser el animador o lo que sea que muestre el pez todo
    public Animator fade;
    public bool isFishing;
    float timing = 3f;
    float bitingTime = 3f;
    bool bite;
    public int fishes = 0;
    int isFish;
    bool away = false;
    public bool test;
    float testTime = 0.1f;
    AudioSource sound;
    public AudioClip fish;
    public AudioClip noFish;
    public AudioClip throwLine;
    public AudioClip pullOut;
    public AudioSource fishSound;
    SpriteRenderer icon;
    public GameObject[] fishIcons;
    public GameObject reel;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>(); //todo
        sound = GetComponent<AudioSource>();
        icon = GameObject.Find("Icon").GetComponent<SpriteRenderer>();
        if (GameStats.stats.fishes == 1)
        {
            fishIcons[0].SetActive(true);
        }
        if (GameStats.stats.fishes == 2)
        {
            fishIcons[1].SetActive(true);
        }
        if (GameStats.stats.fishes == 3)
        {
            fishIcons[2].SetActive(true);
        }
	}
	
	// Update is called once per frame
	void Update () {
        
        
        GameStats.stats.fishes = fishes;
        // El jugador presiona antes de que muerda el pez entonces no saca nada
        if (Input.GetButtonDown("Interact") && bitingTime > 0 && isFishing && !test && anim.GetBool("Again") == false && !bite)
        {
            anim.SetTrigger("noFish");//todo
            isFishing = false;
            bitingTime = timing;
            test = true;
            //anim.SetBool("Again", true);
        }
        if (test)
        {
            testTime -= Time.deltaTime;
        }
        //if (testTime <= 0)
        //{
        //    test = false;
        //}
        if (Input.GetButtonDown("Interact") && !isFishing && !test) //empieza a pescar
        {
            icon.enabled = false; 
            anim.SetBool("isFishing", true); //todo
            isFish = (Random.Range(0, 3));
            //anim.SetTrigger("backToFishing");
            isFishing = true;
            bitingTime = Random.Range(3f, 7f);
            bite = false;
            testTime = 0.1f;
            sound.PlayOneShot(throwLine);
            if(anim.GetBool("Again") == true && fishes < 3){
                anim.SetTrigger("Throw");
                anim.SetBool("Again", false);
                //isFishing = false;
            }else
            if (fishes == 3)
            {
                anim.SetBool("isFishing", false);
                fade.SetTrigger("Fade");
                Invoke("Back", 0.3f);
            }

        }
        if (Input.GetButtonDown("Pause") && fishes < 3)
        {
            anim.SetBool("isFishing", false);
            fade.SetTrigger("Fade");
            Invoke("Back", 0.3f);
        }
      
        if (isFishing)
        {
            bitingTime -= Time.deltaTime;
        }
        //El jugador presionó a tiempo para sacar el pez
        if (Input.GetButtonDown("Interact") && bite)
        {
            CancelInvoke("FishGotAway");
            // Sacó un pez
            if (isFish == 0 || isFish == 1)
            {
                anim.SetTrigger("Fish"); //todo
                fishes = fishes + 1;
            }
            //Sacó un pez muerto. Es aleatorio
            if (isFish == 2){
                anim.SetTrigger("deadFish"); //todo
            }
            isFishing = false;
            bitingTime = timing;
            test = true;
            bite = false;
            reel.SetActive(false);
            //anim.SetBool("Again", true);
        }
        // El pez muerde y el jugador tiene 0.5 segundos para presionar y sacar el pez
        if (bitingTime <= 0 && !bite)
        {
            anim.SetTrigger("Bite");//todo
            bite = true;
            Invoke("FishGotAway", 0.5f);
            bitingTime = timing;
            fishSound.enabled = true;
            reel.SetActive(true);
        }
        // El jugador presiona después de que se fue el pez entonces no saca nada
        if (Input.GetButtonDown("Interact") && away)
        {
            anim.SetTrigger("noFish");//todo
            //bitingTime = timing;
            isFishing = false;
            test = true;
            away = false;
        }

        //if (Input.GetButtonDown("Interact") && fishes == 3){
        //    anim.SetBool("isFishing", false);
        //}
	}
    void FishGotAway(){
        bite = false;
        //sprite.enabled = false; //todo
        away = true;
        //anim.SetTrigger("noFish");
        isFishing = false;
        reel.SetActive(false);
        //test = true;
       // anim.SetBool("Again", true);
        //bitingTime = timing;
        //anim.SetBool("isFishing", false);
        //anim.SetBool("Again", true);
    }
    void Back(){
        SceneManager.LoadScene("Lake");
    }
    void Fish(){
        sound.PlayOneShot(fish);
        anim.SetBool("Again", true);
        test = false;
        icon.enabled = true;
        if (GameStats.stats.fishes == 1)
        {
            fishIcons[0].SetActive(true);
        }
        if (GameStats.stats.fishes == 2)
        {
            fishIcons[1].SetActive(true);
        }
        if (GameStats.stats.fishes == 3)
        {
            fishIcons[2].SetActive(true);
        }
    }
    void NoFish(){
        sound.PlayOneShot(noFish);
        anim.SetBool("Again", true);
        test = false;
        isFishing = false;
        icon.enabled = true;
    }
    void PullOut(){
        sound.PlayOneShot(pullOut);
        fishSound.enabled = false;
    }
}
