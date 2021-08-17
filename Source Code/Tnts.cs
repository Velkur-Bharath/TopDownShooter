using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tnts : MonoBehaviour
{
    public GameObject impact,tempo,player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            GameObject explosion= Instantiate(impact, transform.position, Quaternion.identity);
            Destroy(gameObject);
            FindObjectOfType<CameraShake>().shakeitmedium();
            FindObjectOfType<SoundManager>().Play("tnt");
            if (Vector2.Distance(tempo.transform.position, player.transform.position) < 5f)
            {
                PlayerFollowMouse.instance.TakeDamage(10);
            }
            Destroy(explosion, 0.5f);
        }
    }
}
