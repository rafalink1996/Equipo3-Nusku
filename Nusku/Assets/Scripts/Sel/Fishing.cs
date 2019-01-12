using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishing : MonoBehaviour {


    SpriteRenderer sprite; //Podría ser el animador o lo que sea que muestre el pez todo
    bool isFishing;
    float bitingTime = 3f;
    bool bite;

	// Use this for initialization
	void Start () {
        sprite = GetComponent<SpriteRenderer>(); //todo
	}
	
	// Update is called once per frame
	void Update () {
        print("bitingTime = "+ bitingTime); 
        if (Input.GetButtonDown("Interact") && !isFishing) //empieza a pescar
        {
            sprite.enabled = true; //todo
            sprite.color = Color.white;
            isFishing = true;
            bitingTime = Random.Range(3f, 7f);
            bite = false;
        }
        if (isFishing)
        {
            bitingTime -= Time.deltaTime;
        }
        if (Input.GetButtonDown("Interact") && bite)
        {
            CancelInvoke("FishGotAway");
            sprite.color = Color.green; //todo
            isFishing = false;
        }
        if (bitingTime <= 0 && !bite)
        {
            sprite.color = Color.blue;//todo
            bite = true;
            Invoke("FishGotAway", 0.5f); 
        }
	}
    void FishGotAway(){
        bite = false;
        //sprite.enabled = false; //todo
        sprite.color = Color.red;//todo
        bitingTime = 3f;
        isFishing = false;
    }
}
