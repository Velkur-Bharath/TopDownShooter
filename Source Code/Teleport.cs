using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform tshop;

    void OnTriggerEnter2D(Collider2D col)
    {
            if (col.gameObject.tag == "Player")
            {
            FindObjectOfType<SoundManager>().Play("teleport");
            col.gameObject.transform.position = tshop.position;
            }       
    }
}
