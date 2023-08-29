using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelUnlock : MonoBehaviour
{
    int CurrentSave;
    int LevelStar;
    int CurrentLevel;
    public GameObject Star1;
    public GameObject Star2;
    public GameObject Star3;
    public static int thisbtnlvl = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("CurLevel"))
        {
            CurrentSave = PlayerPrefs.GetInt("CurLevel");
        }
        else
        {
            CurrentSave = 1;
            PlayerPrefs.SetInt("CurLevel", CurrentSave);
        }
        if (Int32.Parse(gameObject.GetComponentInChildren<TMP_Text>().text) > 280)
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = true;
        }
        CurrentLevel = Int32.Parse(gameObject.GetComponentInChildren<TMP_Text>().text);
        if(gameObject.GetComponent<Button>().interactable == true)
        {
            if (PlayerPrefs.HasKey("lvlstar"+CurrentLevel))
            {
                LevelStar = PlayerPrefs.GetInt("lvlstar"+CurrentLevel);
            }
            else
            {
                LevelStar = 0;
                PlayerPrefs.SetInt("lvlstar"+CurrentLevel, LevelStar);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.HasKey("lvlstar" + CurrentLevel))
        {
            LevelStar = PlayerPrefs.GetInt("lvlstar" + CurrentLevel);
        }
        if (LevelStar == 1)
        {
            Star1.SetActive(true);
        }
        if (LevelStar == 2)
        {
            Star2.SetActive(true);
        }
        if (LevelStar == 3)
        {
            Star3.SetActive(true);
        }
    }
    public void lvlthis()
    {
        SoundManage.PlaySound("lvlclick");
        thisbtnlvl = Int32.Parse(gameObject.GetComponentInChildren<TMP_Text>().text);
    }
    
}
