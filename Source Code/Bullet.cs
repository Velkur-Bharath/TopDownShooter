using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject Effect;
    public float bulletspeed = 0.5f;
    private Vector2 dir;
    public AudioClip gunshootpistol;


    void Start()
    {
        transform.position = GameObject.Find("Bulletpos").transform.position;
        dir = GameObject.Find("Dir").transform.position;
    }

  
    void Update()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, dir, bulletspeed*Time.deltaTime);

        Destroy(gameObject, 1.5f);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        
        GameObject HitEffect= Instantiate(Effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(HitEffect, 0.3f);
    }
}
