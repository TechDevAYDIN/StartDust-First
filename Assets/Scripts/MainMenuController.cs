using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    Vector3 startPosition = new Vector3(25, 0, 0);
    Vector3 firstPosition = new Vector3(0, 0, -10);
    Vector3 touchStart;
    Vector3 yPos = new Vector3(0, 0, 0);
    public GameObject intro1cnv;
    public GameObject intro2cnv;
    public GameObject intro3cnv;
    public Button Crt1, Crt2;
    public int control;
    public int audioMute;
    public GameObject muteIco1, muteIco2;

    void Start()
    {
        transform.position = new Vector3(0,0,-10);
        if (!(PlayerPrefs.HasKey("intro")))
        {
            intro1cnv.SetActive(true);
        }
        if (PlayerPrefs.HasKey("Controller"))
        {
            control = PlayerPrefs.GetInt("Controller");
        }
        if (PlayerPrefs.HasKey("AudioMute"))
        {
            audioMute = PlayerPrefs.GetInt("AudioMute");
        }
        else
        {
            audioMute = 0;
            PlayerPrefs.SetInt("AudioMute", audioMute);
        }
        
    }

    void Update()
    {
        if (audioMute == 1)
        {
            muteIco1.SetActive(false);
            muteIco2.SetActive(true);
            AudioListener.pause = true;
        }
        if (audioMute == 0)
        {
            muteIco1.SetActive(true);
            muteIco2.SetActive(false);
            AudioListener.pause = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (transform.position == new Vector3(0, 0, -10))
            {
                Application.Quit();
            }
            else
            {
                transform.position = new Vector3(0, 0, -10);
            }
        }
        if (Input.GetMouseButtonDown(0) && Camera.main.transform.position.x > 24) 
        {
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButton(0) && Camera.main.transform.position.x > 24)
        {
            Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction.x = 0;
            direction.z = 0;
            transform.position += direction;
        }
        if (transform.position.x == 25 && transform.position.y > 0) 
        {
            yPos.y = -transform.position.y;
            transform.position += yPos;
        }
        if (transform.position.x == 25 && transform.position.y < -71)
        {
            yPos.y = -71;
            transform.position = new Vector3(25,yPos.y,-10);
        }
        if (control == 0)
        {
            Crt1.interactable = false;
            Crt2.interactable = true;
        }
        if(control == 1)
        {
            Crt1.interactable = true;
            Crt2.interactable = false;
        }
    }
    public void StartButton()
    {
        SoundManage.PlaySound("MSClick");
        LevelUnlock.thisbtnlvl = PlayerPrefs.GetInt("CurLevel");
    }
    public void ChoseButton()
    {
        SoundManage.PlaySound("MSClick");
        transform.position += startPosition;
    }
    public void OptionsButton()
    {
        SoundManage.PlaySound("MSClick");
        transform.position -= startPosition;
    }
    public void QuitButton()
    {
        SoundManage.PlaySound("MSClick");
        Application.Quit();
    }
    public void BackButton()
    {
        SoundManage.PlaySound("MSClick");
        transform.position = firstPosition;
    }
    public void Level1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void intro1()
    {
        intro2cnv.SetActive(true);
        intro1cnv.SetActive(false);       
    }
    public void intro2()
    {
        intro3cnv.SetActive(true);
        intro2cnv.SetActive(false);
    }
    public void intro3()
    {
        intro3cnv.SetActive(false);
        PlayerPrefs.SetInt("intro", 1);
    }
    public void crt1btn()
    {
        PlayerPrefs.SetInt("Controller", 0);
        control = 0;
    }
    public void crt2btn()
    {
        PlayerPrefs.SetInt("Controller", 1);
        control = 1;
    }
    public void muteBtn()
    {
        if(audioMute == 0)
        {
            audioMute = 1;
            PlayerPrefs.SetInt("AudioMute", audioMute);
        }
        else if (audioMute == 1)
        {
            audioMute = 0;
            PlayerPrefs.SetInt("AudioMute", audioMute);
        }
    }
}
