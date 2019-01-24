using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fishing : MonoBehaviour {


    Animator anim; //Podría ser el animador o lo que sea que muestre el pez todo
    public Animator fade;
    public bool isFishing;
    float bitingTime = 3f;
    bool bite;
    public int fishes = 0;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>(); //todo
	}
	
	// Update is called once per frame
	void Update () {
        GameStats.stats.fishes = fishes;
        if (Input.GetButtonDown("Interact") && !isFishing) //empieza a pescar
        {
            anim.SetBool("isFishing", true); //todo
            //anim.SetTrigger("backToFishing");
            isFishing = true;
            bitingTime = Random.Range(3f, 7f);
            bite = false;
            if(anim.GetBool("Again") == true && fishes < 3){
                anim.SetTrigger("Throw");
            }else
            if (fishes == 3)
            {
                anim.SetBool("isFishing", false);
                fade.SetTrigger("Fade");
                Invoke("Back", 0.3f);
            }
        }
        //if (Input.GetButtonDown("Interact") && anim.GetBool("Again") == true && !isFishing)
        //{
        //    anim.SetTrigger("Throw");
        //    anim.SetBool("Again", false);
        //    print("hello");
        //}
        if (isFishing)
        {
            bitingTime -= Time.deltaTime;
        }
        if (Input.GetButtonDown("Interact") && bite)
        {
            CancelInvoke("FishGotAway");
            anim.SetTrigger("Fish"); //todo
            isFishing = false;
            fishes = fishes + 1;
            anim.SetBool("Again", true);
        }
        if (bitingTime <= 0 && !bite)
        {
            anim.SetTrigger("Bite");//todo
            bite = true;
            Invoke("FishGotAway", 0.5f); 
        }
        //if (Input.GetButtonDown("Interact") && fishes == 3){
        //    anim.SetBool("isFishing", false);
        //}
	}
    void FishGotAway(){
        bite = false;
        //sprite.enabled = false; //todo
        anim.SetTrigger("noFish");//todo
        bitingTime = 3f;
        isFishing = false;
        anim.SetBool("Again", true);
    }
    void Back(){
        SceneManager.LoadScene("Lake");
    }
}
