using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : MonoBehaviour
{
    Rigidbody2D rb;
    public Transform target;
    public float speed;
    private Animator anim;
    public GameObject BombBlast;
    public int health = 80;
    public static int dam=40;
    public GameObject Pickup;
    //public AudioClip blast;
    public static Bomber instance;
    int isdamage;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.Find("player").transform;
        
    }
    void Start()
    {
        if (instance == null) { instance = this; }
       /* isdamage = PlayerPrefs.GetInt("DamageBuy");

        if (isdamage == 4) dam = 40;
        else if (isdamage == 3) dam = 45;
        else if (isdamage == 2) dam = 50;
        else if (isdamage == 1) dam = 55;*/
    }
    void Update()
    {
        if (PlayerFollowMouse.instance.gameover == true)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        Rotation();
        FollowThePlayer();
        if (health <= 0)
        {
            Scores.instance.number += 5;
            Scores.instance.score.text = (Scores.instance.number).ToString();
            Scores.instance.gameoverscore.text = (Scores.instance.number).ToString();
            Destroy(gameObject);
            Instantiate(Pickup, transform.position, Quaternion.identity);
        }
    }

    void Rotation()
    {
        Vector2 Dir = target.gameObject.GetComponent<Rigidbody2D>().position-rb.position;
        float angle = Mathf.Atan2(Dir.y, Dir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }
    void FollowThePlayer()
    {

        if (Vector2.Distance(transform.position, target.position) > 0.7f)
        {           
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        if (Vector2.Distance(rb.position, target.transform.position) <= 0.7f && PlayerFollowMouse.instance.gameover==false)
        {
            anim.SetBool("Blast",true);
            FindObjectOfType<CameraShake>().shakeitmedium();
            FindObjectOfType<SoundManager>().Play("bomber");                   
        }
    }
    void OnCollisionEnter2D(Collision2D Col)
    {
        if (Col.gameObject.tag == "Bullet")
        {
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
        PlayerFollowMouse.instance.TakeDamage(damage);
    }
    void Blast()
    {
        GameObject HitEffect = Instantiate(BombBlast, transform.position, Quaternion.identity);
        Destroy(HitEffect, 0.5f);
        Destroy(gameObject);
    }
}
