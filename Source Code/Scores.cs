using UnityEngine.UI;
using UnityEngine;

public class Scores : MonoBehaviour
{
    public Text score,gameoverscore;
    public static Scores instance;
    public int number = 0,coinscore=0;
    public Text highscore,highscoreforcoin,coin;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        //DontDestroyOnLoad(transform.gameObject);
    }

    void Start()
    {
        highscore.text = PlayerPrefs.GetInt("HighScore",0).ToString();
    }

    public void highScore()
    {
        
        coinscore = number / 50;
        ShopManager.CoinScore = coinscore;
        if (number > PlayerPrefs.GetInt("HighScore", 0))
        { 
            PlayerPrefs.SetInt("HighScore", number);
            highscore.text = number.ToString();
                       
            //ShopManager.instance.number = coinscore;
        }       
    }

    void Update()
    {
        highScore();
        coin.text = PlayerFollowMouse.instance.Coins.ToString();
        highscoreforcoin.text = coinscore.ToString();
    }

    //keep a button to reset the scores

    /*public void ResetScores()
    {
        PlayerPrefs.DeleteKey("HighScore");
        highscore.text = "0";
    }*/
}
