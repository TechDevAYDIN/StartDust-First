using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Rigidbody2D rb2;
    public static float speed = 2.0f;
    [SerializeField] private Transform Playerball = null;
    public float orthSpeed;
    public static float slowdownFactor = 0.05f;
    Vector3 initialPosition;
    Vector3 newPosition;
    Vector3 ballPos;
    public GameObject gameCanvas;
    public GameObject deadCanvas;
    public GameObject upgradeCanvas;
    public GameObject dupgradeCanvas;
    public GameObject escapeCnv;
    private void Start()
    {
        slowdownFactor = 0.26f - (0.02f * PlayerPrefs.GetInt("CurSlow"));
    }
    void Update()
    {
        if (upgradeCanvas.activeSelf == true && Input.GetKeyDown(KeyCode.Escape) || gameCanvas.activeSelf == true && Input.GetKeyDown(KeyCode.Escape) || deadCanvas.activeSelf == true && Input.GetKeyDown(KeyCode.Escape) || dupgradeCanvas.activeSelf == true && Input.GetKeyDown(KeyCode.Escape))
        {
            escapeCnv.SetActive(true);
        }
        if (Input.GetMouseButtonDown(0) && movement.character.charEnergy > 0 && Time.timeScale > 0.04f)
        {
            DoSlowMotion();
        }
        if (Input.GetMouseButtonUp(0) && Time.timeScale > 0.04f)
        {
            Time.timeScale = 1f;
        }
        float x = Playerball.transform.position.x;
        float rbx = rb2.velocity.x;
        float y = Playerball.transform.position.y;
        float rby = rb2.velocity.y;
        float z = -10;

        if (rbx > 18)
        {
            rbx = 18;
        }
        if (rby > 21)
        {
            rby = 21;
        }
        if (rbx < -18)
        {
            rbx = -18;
        }
        if (rby < -21)
        {
            rby = -21;
        }
        ballPos = new Vector3(x, y, z);
        newPosition = new Vector3(x + rbx * 1.2f, y + rby * 0.8f, z);
        transform.position = Vector3.Slerp(transform.position, newPosition, speed * Time.deltaTime);

        /// <summary>
        /// Bu kısım Hıza bağlı olarak kamerayı uzaklaştırır
        /// </summary>
        float velx = rb2.velocity.x * rb2.velocity.x;
        float vely = rb2.velocity.y * rb2.velocity.y;
        if (velx < 1)
        {
            velx = 1;
        }
        if (vely < 1)
        {
            vely = 1;
        }
        float velz = velx + vely;
        velz = math.sqrt(velz);
        if (velz < 5)
        {
            velz = 5;
        }
        if (velz > 9)
        {
            velz = 9;
        }
        Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, velz, orthSpeed);

        /// <summary>
        ///Bu kısım Hız 5.5 ten büyükse titreşim verir
        /// </summary>
        /*
        if (velz > 5.5)
        {
            initialPosition = transform.position;
        }
        if (velz > 5.5f && Time.timeScale == 1)
        {
            Camera.main.transform.position = initialPosition + (UnityEngine.Random.insideUnitSphere * velz) / 720;

        }
        */
        /// <summary>
        /// Bu kısım Ağır Çekim Modundayken Kamerayı Ortalar
        /// </summary>        
        if (Time.timeScale == slowdownFactor && movement.character.charEnergy > 0 && movement.character.controller == 0) 
        {
            transform.position = Vector3.Slerp(transform.position, ballPos + movement.goingPos/movement.mvmntCam, speed*0.05f);
        }
        if (Time.timeScale == slowdownFactor && movement.character.charEnergy > 0 && movement.character.controller == 1)
        {
            transform.position = Vector3.Slerp(transform.position, ballPos + (movement.goingPos / movement.mvmntCam) / 2, speed * 0.05f);
        }
    }
    public void DoSlowMotion()
    {
        Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }
    public void BackGame()
    {
        SoundManage.PlaySound("MSClick");
        escapeCnv.SetActive(false);
    }
}
