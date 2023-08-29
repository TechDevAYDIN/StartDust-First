using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class onDead : MonoBehaviour
{
    public GameObject gameCanvas;
    public GameObject deadCanvas;
    public GameObject upgradeCanvas;
    public Text lastScore;
    public Text UiScore;
    public Text UiMoney;
    public int nextLevel;
    public int lpara;
    int firstMoney;

    private void Start()
    {
        lpara = (movement.character.Score / 100) * PlayerPrefs.GetInt("ParaMultipler");
        firstMoney = PlayerPrefs.GetInt("CurMoney") - lpara;
    }
    void Update()
    {
        UiScore.text = lastScore.text;
        if (this.gameObject.activeSelf)
        {
            gameCanvas.SetActive(false);
        }
        UiMoney.text = "Para: " +(firstMoney + " + "+ lpara);
        if(movement.character.reklampara3x == 1)
        {
            UiMoney.text = "Para: " + (firstMoney + " + " + (lpara*3));
        }

    }
    public void MenuButon()
    {
        SoundManage.PlaySound("MSClick");
        SceneManager.LoadScene("MainMenu");
    }
    public void resButon()
    {
        SoundManage.PlaySound("MSClick");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void nextButon()
    {
        SoundManage.PlaySound("MSClick");
        nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        LevelUnlock.thisbtnlvl = nextLevel;
    }
    public void upMenuButon()
    {
        SoundManage.PlaySound("MSClick");
        upgradeCanvas.SetActive(true);
        gameObject.SetActive(false);
    }
    public void restartAllGame()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
}
