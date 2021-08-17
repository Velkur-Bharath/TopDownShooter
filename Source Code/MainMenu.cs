using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject Shop,popup,stats;
    //public bool playing = false;
    //public int lives = 5;public Text life;
    //public static int live=5;int livess;
    public static MainMenu instance;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        //life.text = PlayerPrefs.GetInt("life",5).ToString();
        //lives = PlayerPrefs.GetInt("life", live);
    }

    void Update()
    {
        //PlayerPrefs.SetInt("life", lives);
        //livess = PlayerPrefs.GetInt("Int");
        /*if (lives < 5 && lives > 0)
        {
            StartCoroutine(lifeincrease());
        }
        else
        {
            StopCoroutine(lifeincrease());
        }*/
    }

    public void Play()
    {
        FindObjectOfType<AudioManager>().Play("button");
        SceneManager.LoadScene("ActualGame");
        ShopManager.playing = true;
        stats.SetActive(false);
        /* if (lives > 0)
         {
             SceneManager.LoadScene("ActualGame");
             ShopManager.playing = true;
             lives--;
             stats.SetActive(false);
         }
         else
         {
             StartCoroutine(showpopup());
         }*/
    }

    public void shop()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        Shop.SetActive(true);
        ShopManager.thecoininitial +=ShopManager.instance.number;

    }

    public void Exit()
    {
        FindObjectOfType<AudioManager>().Play("button");
        Application.Quit();
    }

    /*public void adforlives()
    {
        life.text= PlayerPrefs.GetInt("life", 5).ToString();
        lives = 5;
    }*/

   // public void Stats()
    //{
    //    StartCoroutine(showstats());
        
  //  }

  /*  IEnumerator showpopup()
    {
        popup.SetActive(true);
        yield return new WaitForSeconds(3f);
        popup.SetActive(false);
        StopCoroutine(showpopup());
    }*/

    /*IEnumerator showstats()
    {
        stats.SetActive(true);
        yield return new WaitForSeconds(5f);
        stats.SetActive(false);
        StopCoroutine(showstats());
    }*/

   /* IEnumerator lifeincrease()
    {                
            yield return new WaitForSeconds(30f);
            lives++;
            life.text = PlayerPrefs.GetInt("life",lives).ToString();               
    }*/
}
