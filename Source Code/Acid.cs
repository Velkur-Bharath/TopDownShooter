using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acid : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            StartCoroutine(lowhealth());
            FindObjectOfType<SoundManager>().Play("acid walk");
        }
    }

    IEnumerator lowhealth()
    {
        PlayerFollowMouse.instance.TakeDamage(3);
        yield return new WaitForSeconds(0.5f);
        PlayerFollowMouse.instance.TakeDamage(3);
        yield return new WaitForSeconds(0.5f);
        StopCoroutine(lowhealth());
    }
}
