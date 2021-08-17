using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawners : MonoBehaviour
{
    
    public GameObject[] enimies;
    public float spawnRadius = 100f;
    public float time;
    Vector2 spawnPos;
    public GameObject wave1, wave2, wave3,waver1,waver2,waver3,plus1;


    void Start()
    {        
        StartCoroutine(TimerToSpawnwave1());

        if (PlayerFollowMouse.instance.Coins > 25 && PlayerFollowMouse.instance.Coins <= 150)
        {
            StartCoroutine(showplus1());
        }
        else if (PlayerFollowMouse.instance.Coins > 150)
        {
            StartCoroutine(showplus1());
        }
    }
    void Update()
    {
        if (PlayerFollowMouse.instance.gameover == true)
        {
            StopCoroutine(TimerToSpawnwave1());
        }
        if (PlayerFollowMouse.instance.Coins == 0&& PlayerFollowMouse.instance.Coins <= 25)
        {           
            wave1.SetActive(true);
            waver1.SetActive(true);
        }
        else if(PlayerFollowMouse.instance.Coins > 25 && PlayerFollowMouse.instance.Coins <= 150)
        {
            wave1.SetActive(false);
            wave2.SetActive(true);
            waver2.SetActive(true);
            waver1.SetActive(false);
        }
        else if(PlayerFollowMouse.instance.Coins > 150)
        {
            wave2.SetActive(false);
            wave3.SetActive(true);
            waver3.SetActive(true);
            waver2.SetActive(false);
        }
    }

    IEnumerator TimerToSpawnwave1()
    {
        if (PlayerFollowMouse.instance.GameOver == true)
        {
            spawnPos = GameObject.Find("player").transform.position;
        }
        spawnPos += Random.insideUnitCircle.normalized * spawnRadius;

        Instantiate(enimies[Random.Range(0, enimies.Length)], spawnPos, Quaternion.identity);
        yield return new WaitForSeconds(time);
        StartCoroutine(TimerToSpawnwave1());
    }
    IEnumerator showplus1()
    {
        plus1.SetActive(true);
        yield return new WaitForSeconds(2f);
        plus1.SetActive(false);
        StopCoroutine(showplus1());
    }
}
