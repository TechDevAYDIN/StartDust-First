using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WormHole : MonoBehaviour
{
    float x;
    float y;
    int lvlStar;
    public float varMesafe = 500;
    public float uzakMesafe = 1100;
    int altScoreLimit = 1000;
    public GameObject passedCanvas;
    public GameObject Star1;
    public GameObject Star2;
    public GameObject Star3;
    void Start()
    {
        //varmesafe = LevelSelector.varMesafe;
        x = Random.Range(-uzakMesafe, uzakMesafe);
        y = Random.Range(-uzakMesafe, uzakMesafe);
        while (x > -varMesafe && x < varMesafe && y > -varMesafe && y < varMesafe)
        {
            x = Random.Range(-uzakMesafe, uzakMesafe);
            y = Random.Range(-uzakMesafe, uzakMesafe);
        }
        transform.position = new Vector3(x, y);
        gameObject.GetComponent<Rigidbody2D>().AddTorque(-1000000);
        altScoreLimit = movement.character.altScor;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player" && movement.character.Score > 0) 
        {   
            if(SceneManager.GetActiveScene().buildIndex == PlayerPrefs.GetInt("CurLevel"))
            {
                PlayerPrefs.SetInt("CurLevel", PlayerPrefs.GetInt("CurLevel")+1);
            }
            passedCanvas.SetActive(true);
            movement.character.charEnergy = 0;
            collision.gameObject.SetActive(false);
            if (movement.character.Score < altScoreLimit)
            {
                lvlStar = 1;
                Star1.SetActive(true);
                SoundManage.PlaySound("Passed");
                addMoney((movement.character.Score / 100) * PlayerPrefs.GetInt("ParaMultipler"));
                PlayerPrefs.SetInt("lvlstar" + SceneManager.GetActiveScene().buildIndex, lvlStar);
                PlayerPrefs.SetInt("CurMoney", PlayerPrefs.GetInt("CurMoney") + (movement.character.Score / 100) * (5 + PlayerPrefs.GetInt("ParaMultipler")));
            }
            if (movement.character.Score >= altScoreLimit*4 && movement.character.Score < altScoreLimit*8)
            {
                lvlStar = 2;
                Star2.SetActive(true);
                SoundManage.PlaySound("Passed");
                addMoney((movement.character.Score / 100) * PlayerPrefs.GetInt("ParaMultipler"));
                PlayerPrefs.SetInt("lvlstar" + SceneManager.GetActiveScene().buildIndex, lvlStar);
                PlayerPrefs.SetInt("CurMoney", PlayerPrefs.GetInt("CurMoney") + (movement.character.Score / 100) * (5 + PlayerPrefs.GetInt("ParaMultipler")));
            }
            if (movement.character.Score >= altScoreLimit*8)
            {
                lvlStar = 3;
                Star3.SetActive(true);
                SoundManage.PlaySound("Passed");
                addMoney((movement.character.Score / 100) * PlayerPrefs.GetInt("ParaMultipler"));
                PlayerPrefs.SetInt("lvlstar" + SceneManager.GetActiveScene().buildIndex, lvlStar);
                PlayerPrefs.SetInt("CurMoney",PlayerPrefs.GetInt("CurMoney")+ (movement.character.Score/100)*(5+PlayerPrefs.GetInt("ParaMultipler")));
            }

        }
    }
    public void addMoney(int addedMoney)
    {
        PlayerPrefs.SetInt("CurMoney", PlayerPrefs.GetInt("CurMoney") + addedMoney);
    }
}
