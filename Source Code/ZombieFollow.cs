using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFollow : MonoBehaviour
{
    public Transform player;
    public float speed=2f;
    private Rigidbody2D rb;
    private Animator anim;
    public int health = 100;
    public static int dam=40;
    public GameObject Pickup;
    //private AudioSource attacking;
    public static ZombieFollow instance;
    int isdamage;


    void Awake()
    {
        
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //attacking = GetComponent<AudioSource>();
    }
    void Start()
    {
        if (instance == null) { instance = this; }
       /* isdamage = PlayerPrefs.GetInt("DamageBuy");

        if (isdamage == 4) dam = 40;
        else if (isdamage == 3) dam = 45;
        else if (isdamage == 2) dam = 50;
        else if (isdamage == 1) dam = 55;
    */}

    void Update()
    {
        if (PlayerFollowMouse.instance.gameover == true)
        {
            Destroy(gameObject);
        }
    }
    
    void FixedUpdate()
    {
        FollowPlayer();
        Rotation();
        if (health <= 0)
        {
            Scores.instance.number +=10;
            Scores.instance.score.text = (Scores.instance.number).ToString();
            Scores.instance.gameoverscore.text = (Scores.instance.number).ToString();
            anim.SetTrigger("Die");
            Destroy(gameObject);
            Instantiate(Pickup, transform.position, Quaternion.identity);
        }
    }

    void FollowPlayer()
    {
        if (PlayerFollowMouse.instance.gameover == false)
        {
            if (Vector2.Distance(transform.position, player.transform.position) > 0.7f)
            {
                anim.SetBool("Attack", false);
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            if (Vector2.Distance(transform.position, player.transform.position) <= 0.7f&&
                PlayerFollowMouse.instance.gameover==false)
            {
                FindObjectOfType<SoundManager>().Play("zombies");
                anim.SetBool("Attack",true);                
            }
        }
    }

    void Rotation()
    {
        if (PlayerFollowMouse.instance.gameover == false)
        {
            Vector2 dir = player.gameObject.GetComponent<Rigidbody2D>().position - rb.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
        }
    }
    void OnCollisionEnter2D(Collision2D Col)
    {
        
        if (Col.gameObject.tag=="Bullet")
        {
            anim.SetTrigger("Hit");
            TakeDamage(dam);
            FindObjectOfType<CameraShake>().shakeitlow();
        }
        if (Col.gameObject.tag == "tnt")
        {
            health = 0;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        
    }
    void Dodamage(int damage)
    {
        PlayerFollowMouse.instance.TakeDamage( damage);
    }
}
