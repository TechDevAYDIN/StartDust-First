using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class movement : MonoBehaviour
{
    public static movement character;
    public float BallPower;
    public Rigidbody2D rb;

    public Vector2 minimumpower;
    public Vector2 maximumpower;
    public LineRenderer lr;
    Vector2 ballForce;
    public static Vector3 goingPos;
    Vector3 startPos;
    Vector3 currentpoint;
    Vector3 endPos;
    Vector3 camStartPos;
    Vector3 camCurrentpoint;
    Camera cam;
    public static float mvmntCam=2.5f;
    public Text Score_text = null;
    public int Score = 0;
    public GameObject deadCanvas;
    public float charEnergy;
    public Image Barr;
    float barmax;
    public Image progBarr;
    public Image star2;
    public Image star3;
    public int altScor;
    public int controller;
    public GameObject ControllerCanvas;
    public Text thisLevel;
    public GameObject escapeCnv;
    public int reklampara3x;
    private void Awake()
    {
        reklampara3x = 0;
        character = this;
        lr = GetComponent<LineRenderer>();
        endln();
    }
    void Start()
    {
        cam = Camera.main;
        Application.targetFrameRate = 60;
        rb.AddTorque(500, ForceMode2D.Force);
        charEnergy = 80 + (20 * PlayerPrefs.GetInt("CurEnergy"));
        barmax = charEnergy;
        BallPower = (50 + (5 * PlayerPrefs.GetInt("CurSpeed"))) * 2;
        if (PlayerPrefs.HasKey("Controller"))
        {
            controller = PlayerPrefs.GetInt("Controller");
        }
        else
        {
            ControllerCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    void Update()
    {
        /// <summary>
        /// Bu kısım Dokun ve Git Kontrolu yapar
        /// </summary>    
        if (controller == 0 && charEnergy > 0 && Time.timeScale > 0.05f)
        {
            if (Input.GetMouseButtonDown(0))
            {
            }
            if (Input.GetMouseButton(0))
            {
                charEnergy -= 0.1f;
                startPos = transform.position;
                startPos.z = -5;
                currentpoint = cam.ScreenToWorldPoint(Input.mousePosition);
                currentpoint.z = -5;
                goingPos = new Vector3(Mathf.Clamp(currentpoint.x - startPos.x, minimumpower.x, maximumpower.x), Mathf.Clamp(currentpoint.y - startPos.y, minimumpower.y, maximumpower.y), -5);
                drawln(startPos, currentpoint + (goingPos / 3) * 2);
            }
            if (Input.GetMouseButtonUp(0))
            {
                SoundManage.PlaySound("Move");
                rb.velocity = Vector3.zero;
                endPos = cam.ScreenToWorldPoint(Input.mousePosition);
                endPos.z = -5;

                ballForce = new Vector2(Mathf.Clamp(endPos.x - startPos.x, minimumpower.x, maximumpower.x), Mathf.Clamp(endPos.y - startPos.y, minimumpower.y, maximumpower.y));
                rb.AddForce(ballForce * (BallPower), ForceMode2D.Impulse);
                endln();
                charEnergy -= 15;
            }
        }
        /// <summary>
        /// Bu kısım Çek Bırak Kontrolu yapar
        /// </summary>    
        if (controller == 1 && charEnergy > 0 && Time.timeScale > 0.05f) 
        {
            mvmntCam = 1f;
            if (Input.GetMouseButtonDown(0))
            {
                startPos = cam.ScreenToWorldPoint(Input.mousePosition);
                camStartPos = cam.transform.position;
            }
            if (Input.GetMouseButton(0))
            {
                charEnergy -= 0.1f;
                startPos.z = -5;
                camStartPos.z = 0;
                camCurrentpoint = cam.transform.position;
                camCurrentpoint.z = 0;
                currentpoint = cam.ScreenToWorldPoint(Input.mousePosition)+(camStartPos-camCurrentpoint);
                currentpoint.z = -5;
                goingPos = new Vector3(Mathf.Clamp(startPos.x - currentpoint.x, minimumpower.x/2, maximumpower.x/2), Mathf.Clamp(startPos.y - currentpoint.y, minimumpower.y/2, maximumpower.y/2), -5);
                drawln(transform.position, transform.position + (goingPos * 2));
            }
            if (Input.GetMouseButtonUp(0))
            {
                rb.velocity = Vector3.zero;
                endPos = cam.ScreenToWorldPoint(Input.mousePosition)+(camStartPos-camCurrentpoint);
                endPos.z = -5;

                ballForce = new Vector2(Mathf.Clamp(startPos.x - endPos.x, minimumpower.x / 2, maximumpower.x / 2), Mathf.Clamp(startPos.y - endPos.y, minimumpower.y / 2, maximumpower.y / 2));
                rb.AddForce(ballForce * ((BallPower-10)*2) , ForceMode2D.Impulse);
                endln();
                charEnergy -= 15;
            }
        }
        if (charEnergy <= 0)
        {
            charEnergy = 0;
            endln();
        }
        if (charEnergy >= barmax)
        {
            charEnergy = barmax;
        }
        Score_text.text = "Score: " + Score;
        thisLevel.text = "Level " +SceneManager.GetActiveScene().buildIndex;
        Barr.fillAmount = Mathf.Lerp(Barr.fillAmount, charEnergy / barmax, Time.deltaTime*10);
        progBarr.fillAmount = Mathf.Lerp(progBarr.fillAmount, (float)Score / (altScor*8), Time.deltaTime * 10);
        Barr.color = Color.Lerp(Barr.color, new Color((barmax-charEnergy)/100, (Barr.fillAmount/2), Barr.fillAmount),Time.deltaTime);
        if(Score >= altScor*4)
        {
            star2.color = new Color(1.0f, 1.0f, 1.0f);
        }
        if (Score >= altScor*8)
        {
            star3.color = new Color(1.0f, 1.0f, 1.0f);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(escapeCnv.activeSelf == true)
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene(0);
            }
            else
            {
                escapeCnv.SetActive(true);
                Time.timeScale = 0f;
            }
            
        }
        if(rb.velocity.x < 0.5f && rb.velocity.y < 0.5f)
        {
            if (charEnergy == 0 && rb.velocity.x < 1 && rb.velocity.y < 1)
            {
                Death();
            }
        }
        
    }
    public void drawln(Vector3 startPos,Vector3 endPos)
    {
        lr.positionCount = 2;
        Vector3[] Allpoint = new Vector3[2];
        Allpoint[0] = startPos;
        Allpoint[1] = endPos;
        lr.SetPositions(Allpoint);
    }

    //drawln 2 Nokta arasına çizgi çizer
    public void endln()
    {
        lr.positionCount = 0;
    }
    public void Death()
    {
        charEnergy = 0;
        addMoney((Score / 100) *PlayerPrefs.GetInt("ParaMultipler"));
        deadCanvas.SetActive(true);
        gameObject.SetActive(false);
    }
    public void addScore(int score)
    {
        Score += score;
    }
    public void addMoney(int addedMoney)
    {
        PlayerPrefs.SetInt("CurMoney", PlayerPrefs.GetInt("CurMoney") + addedMoney);
    }
    public void addEnergy(int addedEner)
    {
        charEnergy += addedEner;
    }
    public void Dragbtn()
    {
        SoundManage.PlaySound("MSClick");
        PlayerPrefs.SetInt("Controller", 1);
        controller = 1;
        Time.timeScale = 1f;
        ControllerCanvas.SetActive(false);
    }
    public void Clickbtn()
    {
        SoundManage.PlaySound("MSClick");
        PlayerPrefs.SetInt("Controller", 0);
        controller = 0;
        Time.timeScale = 1f;
        ControllerCanvas.SetActive(false);
    }
    public void BackGame()
    {
        SoundManage.PlaySound("MSClick");
        escapeCnv.SetActive(false);
        Time.timeScale = 1f;
    }
    public void MainMenuu()
    {
        SoundManage.PlaySound("MSClick");
        escapeCnv.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
