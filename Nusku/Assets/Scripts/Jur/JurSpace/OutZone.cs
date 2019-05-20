using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutZone : MonoBehaviour
{
    GameObject sel;
    public float timer = 1f;
    public bool go;
    // Start is called before the first frame update
    void Start()
    {
        sel = GameObject.Find("Sel");
    }

    // Update is called once per frame
    void Update()
    {
        if (go)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0){
            sel.transform.position = new Vector2(0.83f, 0.1f);
            timer = 1;
            go = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player"){
            go = true;
        }
    }
}
