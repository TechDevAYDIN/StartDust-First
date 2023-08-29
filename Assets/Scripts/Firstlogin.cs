using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Firstlogin : MonoBehaviour
{
    public int FirstLog;
    public Text StartButon_text;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("FirstLogin"))
        {
            PlayerPrefs.SetInt("FirstLogin", 1);
            FirstLog = PlayerPrefs.GetInt("FirstLogin");
        }
        else
        {
            FirstLog = 0;
            PlayerPrefs.SetInt("FirstLogin", FirstLog);
        }
        if(FirstLog == 0)
        {
            StartButon_text.text = "YENİ OYUNA BASLA";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
