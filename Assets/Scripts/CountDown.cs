using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public int countdownTime;
    public Text countdown_text;

    private void Awake()
    {
        countdown_text.gameObject.SetActive(true);
        StartCoroutine("CountdowntoStart");
    }
    IEnumerator CountdowntoStart()
    {
        while (countdownTime > 0)
        {
            Time.timeScale = 0.01f;
            countdown_text.text = countdownTime.ToString();
            yield return new WaitForSeconds(0.005f);

            countdownTime--;
        }
        countdown_text.fontSize = 150;
        SoundManage.PlaySound("MSClick");
        countdown_text.text = "Hedefe Git!";
        Time.timeScale = 1f;
        yield return new WaitForSeconds(0.5f);
        countdown_text.gameObject.SetActive(false);
    }
}
