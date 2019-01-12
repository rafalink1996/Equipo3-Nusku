using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{


    Animator animator;
    GameObject sel;
    SelHealth selHealth;
    PlayerMovement2D move;
    float distanceX;
    float distanceY;
    Transform target;
    public int zombieType = 1;
    public bool randomType = true;
    public float speed;
    public int damage = 10;
    int health = 10;
    // Use this for initialization
    void Start()
    {
        if (randomType)
        {
            zombieType = Random.Range(1, 4);
        }
        GetComponent<Animator>().SetFloat("ZombieType", zombieType);
        animator = GetComponent<Animator>();
        sel = GameObject.FindGameObjectWithTag("Player");
        target = GameObject.FindWithTag("Player").transform;
        selHealth = FindObjectOfType<SelHealth>();
        move = FindObjectOfType<PlayerMovement2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > 0.2f && Vector2.Distance(transform.position, target.position) < 4f && move.canMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            distanceX = Mathf.Abs(this.transform.position.x - sel.transform.position.x);
            distanceY = Mathf.Abs(this.transform.position.y - sel.transform.position.y);
            GetComponent<AudioSource>().enabled = true;
            if (this.transform.position.y < sel.transform.position.y && distanceY > distanceX)
            {
                animator.SetInteger("Direction", 1);
            }
            if (this.transform.position.x < sel.transform.position.x && distanceX > distanceY)
            {
                animator.SetInteger("Direction", 2);
            }
            if (this.transform.position.y > sel.transform.position.y && distanceY > distanceX)
            {
                animator.SetInteger("Direction", 3);
            }
            if (this.transform.position.x > sel.transform.position.x && distanceX > distanceY)
            {
                animator.SetInteger("Direction", 4);
            }
        }
        else
        {
            animator.SetInteger("Direction", 3);
            GetComponent<AudioSource>().enabled = false;
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        if (FindObjectOfType<Glove2D>().hasGlove)
        {
            speed = 1.1f;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            selHealth.TakeDamage(damage);
        }
        if (collision.collider.name == "Bullet")
        {
            health = health - 10;
        }
    }
}
