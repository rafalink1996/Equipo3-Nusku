using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelHealth : MonoBehaviour
{

    public Slider healthSlider;
    public int health;
    bool invincible = false;
    bool dead;
    Animator anim;
    PlayerMovement2D sel;
    GameObject arm;
    SpriteRenderer body;
    SpriteRenderer armG;
    public AudioSource Audio;
    public AudioClip Hit;
    public AudioClip death;

    // Use this for initialization
    void Start()
    {
        healthSlider = GameObject.Find("Canvas/HUD/Health").GetComponent<Slider>();
        anim = GetComponentInChildren<Animator>();
        sel = FindObjectOfType<PlayerMovement2D>();
        arm = GameObject.Find("Sel/Graphics/Arm");
        body = GetComponentInChildren<SpriteRenderer>();
        armG = this.transform.Find("Graphics/Arm").gameObject.GetComponent<SpriteRenderer>();
        health = GameStats.stats.health;
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = health;
        armG.color = body.color;
        if (health <= 0 && !dead)
        {
            anim.SetBool("Dead", true);
            Audio.PlayOneShot(death, 1);
            sel.canMove = false;
            arm.SetActive(false);
            body.color = Color.white;
            StopCoroutine("Flashing");
            dead = true;
        }

    }

    public void TakeDamage(int damageTaken)
    {
        if (invincible == false)
        {
            health = health - damageTaken;
            //PlayerPrefs.SetInt("health", health);
            //PlayerPrefs.Save();

            invincible = true;
            StartCoroutine("Flashing");
            Invoke("ResetInvincibility", 2.5f);
            Audio.PlayOneShot(Hit, 1);
        }
    }
    public void RecoverHealth(int healthRecovered)
    {
        health = health + healthRecovered;
        //PlayerPrefs.SetInt("health", health);
        //PlayerPrefs.Save();
    }
    IEnumerator Flashing()
    {
        for (int i = 0; i < 30; i++)
        {
            body.color = new Color(255, 255, 255, 0);
            yield return new WaitForSeconds(.1f);
            body.color = Color.white;
            yield return new WaitForSeconds(.1f);
        }
    }
    void ResetInvincibility()
    {
        invincible = false;
        StopCoroutine("Flashing");
        body.color = Color.white;
    }
}

    /*
    void gano() {
        GameObject.Find("GameController").GetComponent<GameController>().updateCheckpoint();

        GameObject.Find("GameController").GetComponent<GameController>().destroyLevel(1);
        GameObject.Find("GameController").GetComponent<GameController>().loadLevel(2);


        // el usuario presion la tecla de disparo
        if(Input.GetKey(KeyCode.U)) {

            // preguntamos si tenemos rayo o no
            if (GameObject.Find("GameController").GetComponent<GameController>().playerHasRay() == true)
            {
                // Hacemos el disparo
            } else {
                // reporduimos un uaio de error
            }
        }
    }



}






// ----- Todo esto va en GameController (checkpoint, load level)

private int currentCheckpoint;
private int hasMegaRay;
private int bulletCount;

public void updateHealth() {
    
}

public void updateCheckPoint()
{
    currentCheckpoint += 1;
    PlayerPrefs.SetInt(“checkpoint”, currentCheckpoint);
}

// Getter and Setter
void playerGotARay() {
    hasMegaRay = 1;
    PlayerPrefs.SetInt("hasMegaRay", hasMegaRay);
}

void playerShootTheRay() {
    hasMegaRay = 0;
    PlayerPrefs.SetInt("hasMegaRay", hasMegaRay);
}

bool playerHasRay() {
    if(hasMegaRay == 1) {
        return true;
    } else {
        return false;
    }
}


void Awake() {

    // cargamos la lista de poderes que tiene el usuario
    hasMegaRay = PlayerPrefs.GetInt("hasMegaRay", 0);
    bulletCount = PlayerPrefs.GetInt("bulletCount", 0);


    // neceaitamo saber cual fue el ultimo checkpint alcanzado por el usuario
    currentCheckpoint = PlayerPrefs.GetInt("checkpoint", 0);

    if (currentCheckpoint == 0) { // arranca en el inicio
        
        loadLevel(1);
        movePlayerTo(new Vector3(0, 0));

    }
    else if (currentCheckpoint == 1) { // Mato a la serpiente
        loadLevel(1);
        movePlayerTo(new Vector3(50, 0));

    }
    else if (currentCheckpoint == 2){ // llego donde el mago
        loadLevel(2);
        movePlayerTo(new Vector3(0, 0));
    }

}

void movePlayerTo(Vector3 newPosition) {

    // Movemos el personaje a las coodenada enviadas en el parametro newPosition
    GameObject.Find("Sel").transform.position = newPosition;
}

void loadLevel(int levelToLoad) {

    GameObject newLevel = GameObject.Instantiate(Resources.Load("Levels/Level" + levelToLoad) as GameObject);
}

void destroyLevel(int levelToDestyoy)
{

    GameObject newLevel = GameObject.Instantiate(Resources.Load("Levels/Level" + levelToDestyoy) as GameObject);
}
*/