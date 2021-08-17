using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private Animator anim;
    public GameObject Shop,shopmsg;
    
    void Awake()
    {
        anim = GetComponent<Animator>();
        //StartCoroutine(Shoptext());
    }

    
    void Update()
    {
        if (PlayerFollowMouse.instance.gameover == true)
        {
            Destroy(gameObject);
            Shop.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            
            anim.SetTrigger("OpenChest");
            Shop.SetActive(true);
        }

    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Shop.SetActive(false);
            anim.SetTrigger("CloseChest");
        }
    }

    IEnumerator Shoptext()
    {
        shopmsg.SetActive(true);
        yield return new WaitForSeconds(1f);
        shopmsg.SetActive(false);
        StopCoroutine(Shoptext());
    }

}
