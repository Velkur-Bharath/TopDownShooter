using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour
{
    public void OnClickingPlayAgain()
    {
        FindObjectOfType<SoundManager>().Play("button");
        SceneManager.LoadScene("ActualGame");
    }
    public void OnclickingMainMenu()
    {
        FindObjectOfType<SoundManager>().Play("button");
        SceneManager.LoadScene("MainMenu");
        ShopManager.playing = false;
    }
}
