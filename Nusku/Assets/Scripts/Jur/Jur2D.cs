using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jur2D : MonoBehaviour {


    Animator anim;
    public float direction;
    public float health;
    public float maxHealth;
    public GameObject freeze;
    public GameObject water;
    GameObject sel;
    TextBoxManager textBox;
    JurDialogue dialogue;
    public bool dead;
    public bool froze;
    bool half;
    public SpriteRenderer neck;
    public AudioSource pre;
    public AudioSource batle;
    public AudioSource jurAudio;
    public AudioClip death;
    public AudioClip hit;
    public AudioClip dive;
    public AudioClip emerge;
    public AudioClip whip;
    public AudioClip diveBeams;
    public AudioClip stalactite;
    public AudioClip bite;
    public AudioClip change;
    bool invincible;
    Component[] animator;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        textBox = FindObjectOfType<TextBoxManager>();
        dialogue = FindObjectOfType<JurDialogue>();
        health = maxHealth;
        sel = GameObject.Find("Sel");
        animator = sel.GetComponentsInChildren<Animator>();
   
	}
	
	// Update is called once per frame
	void Update () {
       if (health <= 0 && !dead)
        {
            anim.SetTrigger("Death");
            dead = true;
            jurAudio.PlayOneShot(death, 1.5f);
            GetComponent<CircleCollider2D>().enabled = false;
        }

        if (health <= maxHealth * 0.5f && !half)
        {
            GameObject hp = GameObject.Instantiate(Resources.Load("Prefabs/HP_Bottle") as GameObject);
            hp.transform.position = new Vector3(0.4f, -0.01f);
            hp.name = "HP_Bottle";
            half = true;
        }
        if (textBox.currentLine > textBox.endAtLine && dialogue.lastOne == true)
        {
            anim.SetTrigger("BattleStart");
        }
        neck.color = GetComponent<SpriteRenderer>().color;
     
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Bullet" && !invincible)
        {
            health = health - 10f;
            GetComponent<SpriteRenderer>().color = new Color(179, 0, 255);
            Invoke("ChangeColorBack", 1.5f); 
            jurAudio.PlayOneShot(hit , 0.7f);
            invincible = true;

        }
    }
    void Shoot (){
        GameObject bullet = GameObject.Instantiate(Resources.Load("Prefabs/Jur_Bullet") as GameObject);
        bullet.transform.position = (GameObject.Find("Jur/Mouth").transform.position);
        bullet.name = "Jur_Bullet";
    }
    void HomingBullet()
    {
        GameObject bullet = GameObject.Instantiate(Resources.Load("Prefabs/JurHomingBullet") as GameObject);
        bullet.transform.position = (GameObject.Find("Jur/Mouth").transform.position);
        bullet.name = "JurHomingBullet";
    }
    void IceJavelin()
    {
        GameObject javelin1 = GameObject.Instantiate(Resources.Load("Prefabs/IceJavelin") as GameObject);
        javelin1.transform.position = (GameObject.Find("Jur/Mouth").transform.position);
        javelin1.transform.rotation = Quaternion.Euler(0, 0, Random.Range(-85f, -50f));
        javelin1.name = "IceJavelin";
        GameObject javelin2 = GameObject.Instantiate(Resources.Load("Prefabs/IceJavelin") as GameObject);
        javelin2.transform.position = (GameObject.Find("Jur/Mouth").transform.position);
        javelin2.transform.rotation = Quaternion.Euler(0, 0, Random.Range(-49f, -15f));
        javelin2.name = "IceJavelin";
        GameObject javelin3 = GameObject.Instantiate(Resources.Load("Prefabs/IceJavelin") as GameObject);
        javelin3.transform.position = (GameObject.Find("Jur/Mouth").transform.position);
        javelin3.transform.rotation = Quaternion.Euler(0, 0, Random.Range(-14f, 20f));
        javelin3.name = "IceJavelin";
    }
    void BiteLeft()
    {
        GameObject biteL = GameObject.Instantiate(Resources.Load("Prefabs/Bite_L") as GameObject);
        biteL.transform.position = (GameObject.Find("Jur/Mouth").transform.position);
        biteL.name = "Bite";
    }
    void BiteCenter()
    {
        GameObject biteC = GameObject.Instantiate(Resources.Load("Prefabs/Bite_C") as GameObject);
        biteC.transform.position = (GameObject.Find("Jur/Mouth").transform.position);
        biteC.name = "Bite";
    }
    void BiteRight()
    {
        GameObject biteR = GameObject.Instantiate(Resources.Load("Prefabs/Bite_R") as GameObject);
        biteR.transform.position = (GameObject.Find("Jur/Mouth").transform.position);
        biteR.name = "Bite";
    }
    void ChangeColorBack()
    {
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
        invincible = false;
    }
    void FreezeWater(){
        freeze.SetActive(true);
        water.SetActive(false);
        froze = true;
    }
    void ChangeMusic(){
        pre.enabled = false;
        batle.enabled = true;

    }
    void ReturnMusic() {
        pre.enabled = true;
        batle.enabled = false;
        GameObject shield = GameObject.Instantiate(Resources.Load("Prefabs/Shield") as GameObject);
        shield.name = "Shield";
        sel.transform.localPosition = new Vector3(1.731807f, -0.9665074f, -3.157491f);
        foreach (Animator child in animator)
        {
            child.SetFloat("LastX", -1f);
            child.SetFloat("LastY", 1f);
        }
        sel.GetComponent<PlayerMovement2D>().canMove = false;
        
    }
    void DiveSound() {
        jurAudio.PlayOneShot(dive, 1);
    }
    void EmergeSound() {
        jurAudio.PlayOneShot(emerge, 1);
    }
    void WhipSound() {
        jurAudio.PlayOneShot(whip, 1);
    }
    void DownSound() {
        jurAudio.PlayOneShot(diveBeams, 1);
    }
    void StalactiteSound() {
        jurAudio.PlayOneShot(stalactite, 1);
    }
    void BiteSound(){
        jurAudio.PlayOneShot(bite, 1);
    }
    void FlashIn()
    {
        jurAudio.PlayOneShot(change, 1);
    }
    void SelMove(){
        sel.GetComponent<PlayerMovement2D>().canMove = true;
    }
}
