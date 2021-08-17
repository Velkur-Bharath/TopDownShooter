using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunBullet : MonoBehaviour
{
    public GameObject Effect;
    public float bulletspeed = 0.5f;
    private Vector2 dir1,dir2;
    public GameObject bullet1, bullet2;
    

    void Awake()
    {
       
    }

    void Start()
    {
        
        bullet1.transform.position = GameObject.Find("BulletPos").transform.position;
        bullet2.transform.position = GameObject.Find("BulletPos").transform.position;
        dir1 = GameObject.Find("Dir1").transform.position;
        dir2 = GameObject.Find("Dir2").transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        bullet1.transform.position = Vector2.MoveTowards(bullet1.transform.position, dir1, bulletspeed * Time.deltaTime);
        bullet2.transform.position = Vector2.MoveTowards(bullet2.transform.position, dir2, bulletspeed * Time.deltaTime);

        Destroy(gameObject, 1.5f);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        FindObjectOfType<CameraShake>().shakeitlow();
        GameObject HitEffect = Instantiate(Effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(HitEffect, 0.3f);
    }
}
