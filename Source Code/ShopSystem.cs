using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSystem : MonoBehaviour
{
    public Button armor1, armor2, armor3, health, gun;
    


    public void Onclickingarmor1()
    {
        if (PlayerFollowMouse.instance.Coins >= 60)
        {
            PlayerFollowMouse.instance.Sheild1onoroff = false;
            PlayerFollowMouse.instance.Sheild2onoroff = false;
            PlayerFollowMouse.instance.Sheild0onoroff = true;
            PlayerFollowMouse.instance.maxhealth = 125;
            PlayerFollowMouse.instance.currenthealth = 125;
            PlayerFollowMouse.instance.coin.text = (PlayerFollowMouse.instance.Coins - 60).ToString();
            PlayerFollowMouse.instance.Coins = PlayerFollowMouse.instance.Coins - 60;
            
        }
    }
    public void Onclickingarmor2()
    {
        if (PlayerFollowMouse.instance.Coins >= 120)
        {
            PlayerFollowMouse.instance.Sheild0onoroff = false;
            PlayerFollowMouse.instance.Sheild2onoroff = false;
            PlayerFollowMouse.instance.Sheild1onoroff = true;
            PlayerFollowMouse.instance.maxhealth = 150;
            PlayerFollowMouse.instance.currenthealth = 150;
            PlayerFollowMouse.instance.coin.text = (PlayerFollowMouse.instance.Coins - 120).ToString();
            PlayerFollowMouse.instance.Coins = PlayerFollowMouse.instance.Coins - 120;
        }
    }
    public void Onclickingarmor3()
    {
        if (PlayerFollowMouse.instance.Coins >= 180)
        {
            PlayerFollowMouse.instance.Sheild1onoroff = false;
            PlayerFollowMouse.instance.Sheild0onoroff = false;
            PlayerFollowMouse.instance.Sheild2onoroff = true;
            PlayerFollowMouse.instance.maxhealth = 175;
            PlayerFollowMouse.instance.currenthealth = 175;
            PlayerFollowMouse.instance.coin.text = (PlayerFollowMouse.instance.Coins - 180).ToString();
            PlayerFollowMouse.instance.Coins = PlayerFollowMouse.instance.Coins - 180;
        }
    }
    public void OnClickinghealth()
    {
        if (PlayerFollowMouse.instance.Coins >= 25)
        {
            if (PlayerFollowMouse.instance.Sheild1onoroff == false
            &&PlayerFollowMouse.instance.Sheild0onoroff == false && PlayerFollowMouse.instance.Sheild2onoroff == false)
            {        
                if(PlayerFollowMouse.instance.currenthealth < 100)
                PlayerFollowMouse.instance.healthbuy = true;
            }
            if (  PlayerFollowMouse.instance.Sheild1onoroff == false
            && PlayerFollowMouse.instance.Sheild0onoroff == true && PlayerFollowMouse.instance.Sheild2onoroff == false)
            {
                if(PlayerFollowMouse.instance.currenthealth < 125)
                PlayerFollowMouse.instance.healthbuy = true;
            }
            if ( PlayerFollowMouse.instance.Sheild1onoroff == true
            && PlayerFollowMouse.instance.Sheild0onoroff == false && PlayerFollowMouse.instance.Sheild2onoroff == false)
            {
                if(PlayerFollowMouse.instance.currenthealth < 150)
                    PlayerFollowMouse.instance.healthbuy = true;
            }
            if ( PlayerFollowMouse.instance.Sheild1onoroff == false
&& PlayerFollowMouse.instance.Sheild0onoroff == false && PlayerFollowMouse.instance.Sheild2onoroff == true)
            {
                if(PlayerFollowMouse.instance.currenthealth < 175)
                PlayerFollowMouse.instance.healthbuy = true;
            }
        }
    }
    
    public void OnClickingShotgun()
    {
        if (PlayerFollowMouse.instance.Coins >= 75 && PlayerFollowMouse.instance.ShotGun==false )
        {
            if (PlayerFollowMouse.instance.shotgun == false)
            {
                PlayerFollowMouse.instance.shotGun.SetActive(true);
                PlayerFollowMouse.instance.ShotGun=true;
                PlayerFollowMouse.instance.shotgun = true;
            }
        }
    }
}
