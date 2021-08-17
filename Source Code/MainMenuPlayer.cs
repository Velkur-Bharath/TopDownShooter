using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPlayer : MonoBehaviour
{
    public float  movespeed = 4f;
    public Transform movement, movement1, movement2, movement3;
    public Rigidbody2D rb;
    private float timestoroam;
    // Start is called before the first frame update
    void Start()
    {
        timestoroam = 1;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position != movement.position&& timestoroam == 1)
        {
            rb.position = Vector2.MoveTowards(transform.position, movement.position, movespeed * Time.deltaTime);
           
            rb.rotation = 35;
        }
        else if(transform.position==movement.position)
        {
            timestoroam = timestoroam + 1;
        }
        if (transform.position != movement1.position && timestoroam == 2)
        {
            rb.position = Vector2.MoveTowards(transform.position, movement1.position, movespeed * Time.deltaTime);
            
            rb.rotation = -120;
        }
        else if (transform.position == movement1.position)
        {
            timestoroam = timestoroam + 1;
        }
        if (transform.position != movement2.position && timestoroam == 3)
        {
            rb.position = Vector2.MoveTowards(transform.position, movement2.position, movespeed * Time.deltaTime);
            
            rb.rotation = -230;
        }
        else if (transform.position == movement2.position)
        {
            timestoroam = timestoroam + 1;
        }
        if (transform.position != movement3.position && timestoroam == 4)
        {
            rb.position = Vector2.MoveTowards(transform.position, movement3.position, movespeed * Time.deltaTime);
           
            rb.rotation = -10;
        }
        else if (transform.position == movement3.position)
        {
            timestoroam = 1;
            
        }
    }
}