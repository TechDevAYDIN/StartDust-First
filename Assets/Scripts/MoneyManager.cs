using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public Text moneyText;
    public Text enerText;
    public Text spedText;
    public Text slowText;
    public Text paraMultiText;
    public int money;
    public int energy;
    public int speed;
    public int slowDown;
    public int paraMulti;
    public Button enerButton;
    public Button speedButton;
    public Button slowButton;
    public Button paraMultiButton;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("CurMoney"))
        {
            money = PlayerPrefs.GetInt("CurMoney");
        }
        else
        {
            money = 0;
            PlayerPrefs.SetInt("CurMoney", money);
        }
        if (PlayerPrefs.HasKey("CurEnergy"))
        {
            energy = PlayerPrefs.GetInt("CurEnergy");
        }
        else
        {
            energy = 1;
            PlayerPrefs.SetInt("CurEnergy", energy);
        }
        if (PlayerPrefs.HasKey("CurSpeed"))
        {
            speed = PlayerPrefs.GetInt("CurSpeed");
        }
        else
        {
            speed = 1;
            PlayerPrefs.SetInt("CurSpeed", speed);
        }
        if (PlayerPrefs.HasKey("CurSlow"))
        {
            slowDown = PlayerPrefs.GetInt("CurSlow");
        }
        else
        {
            slowDown = 1;
            PlayerPrefs.SetInt("CurSlow", slowDown);
        }
        if (PlayerPrefs.HasKey("ParaMultipler"))
        {
            paraMulti = PlayerPrefs.GetInt("ParaMultipler");
        }
        else
        {
            paraMulti = 5;
            PlayerPrefs.SetInt("ParaMultipler", paraMulti);
        }
    }

    // Update is called once per frame
    void Update()
    {
        money = PlayerPrefs.GetInt("CurMoney");
        energy = PlayerPrefs.GetInt("CurEnergy");
        speed = PlayerPrefs.GetInt("CurSpeed");
        slowDown = PlayerPrefs.GetInt("CurSlow");
        paraMulti = PlayerPrefs.GetInt("ParaMultipler");
        moneyText.text = "Para : " + money;
        enerText.text = "SEVİYE : " + energy.ToString() + "/10";
        spedText.text = "SEVİYE : " + speed.ToString() + "/10";
        slowText.text = "SEVİYE : " + slowDown.ToString() + "/10";
        paraMultiText.text = "SEVİYE : " + (paraMulti - 4).ToString() + "/10";
        enerButton.GetComponentInChildren<Text>().text = "Satın Al" + Environment.NewLine + ((1000 * (PlayerPrefs.GetInt("CurEnergy") + 4) * 2 / 5)+1000);
        speedButton.GetComponentInChildren<Text>().text = "Satın Al" + Environment.NewLine + ((1000 * (PlayerPrefs.GetInt("CurSpeed") + 4) * 2 / 5)+1000);
        slowButton.GetComponentInChildren<Text>().text = "Satın Al" + Environment.NewLine + ((1000 * (PlayerPrefs.GetInt("CurSlow") + 4) * 2 / 5)+1000);
        paraMultiButton.GetComponentInChildren<Text>().text = "Satın Al" + Environment.NewLine + ((1000 * PlayerPrefs.GetInt("ParaMultipler")*2 / 10)+1000);
        if (money > (1000 * (PlayerPrefs.GetInt("CurEnergy") + 4)*2 / 5)+1000 && PlayerPrefs.GetInt("CurEnergy") < 10)
        {
            enerButton.interactable = true;
        }
        else
        {
            enerButton.interactable = false;
        }
        if (money > (1000 * (PlayerPrefs.GetInt("CurSpeed") + 4)*2 / 5)+1000 && PlayerPrefs.GetInt("CurSpeed") < 10)
        {
            speedButton.interactable = true;
        }
        else
        {
            speedButton.interactable = false;
        }
        if (money > (1000 * (PlayerPrefs.GetInt("CurSlow") + 4)*2 / 5)+1000 && PlayerPrefs.GetInt("CurSlow") < 10)
        {
            slowButton.interactable = true;
        }
        else
        {
            slowButton.interactable = false;
        }
        if (money > (1000 * PlayerPrefs.GetInt("ParaMultipler")*2 / 10)+1000 && PlayerPrefs.GetInt("ParaMultipler") < 14)
        {
            paraMultiButton.interactable = true;
        }
        else
        {
            paraMultiButton.interactable = false;
        }
        if(PlayerPrefs.GetInt("CurEnergy") == 10)
        {
            enerButton.GetComponentInChildren<Text>().text = "MAX";
        }
        if (PlayerPrefs.GetInt("CurSpeed") == 10)
        {
            speedButton.GetComponentInChildren<Text>().text = "MAX";
        }
        if (PlayerPrefs.GetInt("CurSlow") == 10)
        {
            slowButton.GetComponentInChildren<Text>().text = "MAX";
        }
        if (PlayerPrefs.GetInt("ParaMultipler") == 14)
        {
            paraMultiButton.GetComponentInChildren<Text>().text = "MAX";
        }
    }
    public void addMoney(int addedMoney)
    {
        PlayerPrefs.SetInt("CurMoney", PlayerPrefs.GetInt("CurMoney")+addedMoney);
    }
    public void subMoney(int subedMoney)
    {
        PlayerPrefs.SetInt("CurMoney", PlayerPrefs.GetInt("CurMoney") - subedMoney);
    }
    public void upgEnergy()
    {
        SoundManage.PlaySound("Coin");
        subMoney((1000 * (PlayerPrefs.GetInt("CurEnergy") + 4)*2 / 5)+1000);
        PlayerPrefs.SetInt("CurEnergy", PlayerPrefs.GetInt("CurEnergy")+1);
    }
    public void upgSpeed()
    {
        SoundManage.PlaySound("Coin");
        subMoney((1000 * (PlayerPrefs.GetInt("CurSpeed") + 4)*2 / 5)+1000);
        PlayerPrefs.SetInt("CurSpeed", PlayerPrefs.GetInt("CurSpeed") + 1);
    }
    public void upgSlow()
    {
        SoundManage.PlaySound("Coin");
        subMoney((1000 * (PlayerPrefs.GetInt("CurSlow") + 4)*2 / 5)+1000);
        PlayerPrefs.SetInt("CurSlow", PlayerPrefs.GetInt("CurSlow") + 1);
    }
    public void upgPara()
    {
        SoundManage.PlaySound("Coin");
        subMoney((1000 * PlayerPrefs.GetInt("ParaMultipler")*2 / 10)+1000);
        PlayerPrefs.SetInt("ParaMultipler", PlayerPrefs.GetInt("ParaMultipler") + 1);
    }
}
