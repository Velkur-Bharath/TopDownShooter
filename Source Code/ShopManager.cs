using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;
    public Text cointext;
    public int number,issoldred,issoldgreen,issoldpink,isspeed,isdamage,isbullet;
    public GameObject shop;
    public static int CoinS, CoinScore, thecoininitial;
    //int timespeedbought=6,timeboughtbullet=6,timeboughtdamage=4;
    //public GameObject speedst1, speedst2, speedst3, speedst4, speedst5, bulletst1, bulletst2, bulletst3, bulletst4, bulletst5, damagest1, damagest2, damagest3;
    public static bool playing = false;public Button sp, bull, dam;public GameObject popup;
    public static bool shottgun = false;//int red=0, pink=0, green=0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        DontDestroyOnLoad(transform.gameObject);
        
    }
    
    void Start()
    {
        //cointext.text = PlayerPrefs.GetInt("shopcoin", 0).ToString();
        //thecoininitial = PlayerPrefs.GetInt("shopcoin", 0)+ number;
        
        DontDestroyOnLoad(gameObject);
        //starsshow();
    }

    /*public void coinShop()
    {
        
        number = CoinS+ CoinScore;
        PlayerPrefs.SetInt("shopcoin", thecoininitial);
        PlayerPrefs.SetInt("SpeedBuy", timespeedbought);
        PlayerPrefs.SetInt("DamageBuy", timeboughtdamage);
        PlayerPrefs.SetInt("BulletBuy", timeboughtbullet);
        if (timespeedbought > 0 || timeboughtbullet > 0 || timeboughtdamage > 0)
        {
            PlayerPrefs.SetInt("BuySpeeD", timespeedbought);
            PlayerPrefs.SetInt("BuyDamagE", timeboughtdamage);
            PlayerPrefs.SetInt("BuyBulleT", timeboughtbullet);
        }
        cointext.text = thecoininitial.ToString();
        PlayerPrefs.SetInt("BuyReD", red);
        PlayerPrefs.SetInt("BuyGreeN", green);
        PlayerPrefs.SetInt("BuyPinK", pink);
    }
    
    void Update()
    {
        
        coinShop();
        issoldred = PlayerPrefs.GetInt("BuyReD");
        issoldgreen = PlayerPrefs.GetInt("BuyGreeN");
        issoldpink = PlayerPrefs.GetInt("BuyPinK");
        isspeed = PlayerPrefs.GetInt("SpeedBuy");
        isdamage = PlayerPrefs.GetInt("DamageBuy");
        isbullet = PlayerPrefs.GetInt("BulletBuy");
    }

    public void speed()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        if (thecoininitial >= 1500 && timespeedbought>0)
        {
            thecoininitial = thecoininitial - 1500;
            //PlayerFollowMouse.moveSpeed += 0.2f;
            //timespeedbought--;
            PlayerPrefs.SetInt("SpeedBuy", timespeedbought);
        }
        else if (thecoininitial < 1500)
        {
            StartCoroutine(showpopup());
        }
    }

    public void bullet()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        if (thecoininitial >= 1500 && timeboughtbullet>0)
        {
            //PlayerFollowMouse.temporarytimeforshop -= 0.15f;
            thecoininitial = thecoininitial - 1500;
            //timeboughtbullet--;
            PlayerPrefs.SetInt("BulletBuy", timeboughtbullet);
        }
        else if (thecoininitial < 1500)
        {
            StartCoroutine(showpopup());
        }
    }

    public void damage()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        if (thecoininitial >= 2500 && timeboughtdamage>0)
        {
            thecoininitial = thecoininitial - 2500;
            //ZombieFollow.dam += 4;
            //Bomber.dam += 4;
            //timeboughtdamage--;
            PlayerPrefs.SetInt("DamageBuy", timeboughtdamage);
        }
        else if (thecoininitial < 2500)
        {
            StartCoroutine(showpopup());
        }
    }
    
    public void industrymap()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        if (thecoininitial >=5000)
        {
            thecoininitial = thecoininitial - 5000; 
        }
    }
    
    public void swampymap()
    {
        
        FindObjectOfType<AudioManager>().Play("Button");
        if (thecoininitial >= 7000) 
        {
            thecoininitial = thecoininitial - 7000;
        }
        if (thecoininitial < 700)
        {
            StartCoroutine(showpopup());
        }
    }
    
    public void redtorso()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        if (thecoininitial >= 700 && issoldred == 0)
        {
            thecoininitial = thecoininitial - 700;
            PlayerFollowMouse.redtorsoonoroff = true;
            PlayerFollowMouse.greentorsoonoroff = false;
            PlayerFollowMouse.pinktorsoonoroff = false ;
            red = 1;
            PlayerPrefs.SetInt("BuyRed", red);
        }
        else if (thecoininitial < 700)
        {
            StartCoroutine(showpopup());
        }
    }

    public void greentorso()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        if (thecoininitial >= 700 && issoldgreen == 0)
        {
            thecoininitial = thecoininitial - 700;
            PlayerFollowMouse.redtorsoonoroff = false;
            PlayerFollowMouse.greentorsoonoroff = true;
            PlayerFollowMouse.pinktorsoonoroff = false;
            green = 1;
            PlayerPrefs.SetInt("BuyGreen", green);
        }
        else if (thecoininitial < 700)
        {
            StartCoroutine(showpopup());
        }
    }

    public void pinktorso()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        if (thecoininitial >= 700 && issoldpink == 0)
        {
            thecoininitial = thecoininitial - 700;
            PlayerFollowMouse.redtorsoonoroff = false;
            PlayerFollowMouse.pinktorsoonoroff = true;
            PlayerFollowMouse.greentorsoonoroff = false;
            pink = 1;
            PlayerPrefs.SetInt("BuyPink", pink);
        }
        else if (thecoininitial < 700)
        {
            StartCoroutine(showpopup());
        }
    }
    
    public void menu()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        
        shop.SetActive ( false);
    }
    
    public void Watchad()
    {
        thecoininitial += 200;
    }
    */
    public void watchadforsg()
    {
        shottgun = true;
    }

    /*IEnumerator showpopup()
    {
        popup.SetActive(true);
        yield return new WaitForSeconds(3f);
        popup.SetActive(false);
        StopCoroutine(showpopup());
    }

    public void starsshow()
    {
        if (isspeed == 5&&!playing) { speedst1.SetActive (true);timespeedbought = 5; }
        else if (isspeed == 4 && !playing) { speedst1.SetActive(true); speedst2.SetActive(true); timespeedbought = 4; }
        else if (isspeed == 3 && !playing) { speedst1.SetActive(true); speedst2.SetActive(true); speedst3.SetActive(true); timespeedbought = 3; }
        else if (isspeed == 2 && !playing) { speedst1.SetActive(true); speedst2.SetActive(true); speedst3.SetActive(true);
            speedst4.SetActive(true); timespeedbought = 2; }
        else if (isspeed == 1 && !playing) { speedst1.SetActive(true); speedst2.SetActive(true);
            speedst3.SetActive(true); speedst4.SetActive(true); speedst5.SetActive(true);sp.interactable = false; timespeedbought = 1;
        }

        if (isbullet == 5 && !playing) { bulletst1.SetActive(true);timeboughtbullet = 5; }
        else if (isbullet == 4 && !playing) { bulletst1.SetActive(true); bulletst2.SetActive(true); timeboughtbullet = 4; }
        else if (isbullet == 3 && !playing) { bulletst1.SetActive(true); bulletst2.SetActive(true); bulletst3.SetActive(true); timeboughtbullet = 3; }
        else if (isbullet == 2 && !playing) { bulletst1.SetActive(true); bulletst2.SetActive(true); bulletst3.SetActive(true); bulletst4.SetActive(true);
        timeboughtbullet = 2;}
        else if (isbullet == 1 && !playing) { bulletst1.SetActive(true); bulletst2.SetActive(true); 
            bulletst3.SetActive(true); bulletst4.SetActive(true); bulletst5.SetActive(true);bull.interactable = false;timeboughtbullet = 1; }

        if (isdamage == 3 && !playing) { damagest1.SetActive(true); timeboughtdamage = 3; }
        else if (isdamage == 2 && !playing) { damagest1.SetActive(true); damagest2.SetActive(true); timeboughtdamage = 2; }
        else if (isdamage == 1 && !playing) { damagest1.SetActive(true); damagest2.SetActive(true); damagest3.SetActive(true);dam.interactable = false;
            timeboughtdamage = 1; }
        
    }*/
}
