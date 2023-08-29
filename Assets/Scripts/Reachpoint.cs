using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Reachpoint : MonoBehaviour
{
    float x;
    float y;
    float z;
    Vector2 pos;
    Transform cam;
    Vector3 actualScale;
    private GameObject player;
    public GameObject expYell;
    public GameObject expRed;
    public GameObject expBlue;
    public GameObject expBigRed;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (gameObject.tag == "Nocollect")
        {
            ObjectPoolerno.SharedInstance.reuse();
        }
        if (gameObject.tag == "Collects")
        {
            ObjectPooler.SharedInstance.reuse();
            ObjectPooler2.SharedInstance.reuse();
        }
        actualScale = transform.localScale;
    }
        void Update()
    {
        cam = Camera.main.transform;
        pos = gameObject.transform.position; 
        if(pos.x < cam.position.x - 35 || pos.x > cam.position.x + 35 || pos.y < cam.position.y - 25 || pos.y > cam.position.y + 25)
        {
            gameObject.SetActive(false);
            ObjectPooler.SharedInstance.reuse();
            ObjectPooler2.SharedInstance.reuse();
            ObjectPoolerno.SharedInstance.reuse();
        }
        if(transform.localScale.x <= 0.3f && gameObject.tag == "Nocollect")
        {
            gameObject.SetActive(false);
            ObjectPoolerno.SharedInstance.reuse();
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player" && this.gameObject.tag =="Collects")
        {
            gameObject.SetActive(false);
            if(gameObject.name == "Collect2(Clone)")
            {
                SoundManage.PlaySound("NCollect");
                movement.character.addScore(100);
                movement.character.addEnergy(30);
                Instantiate(expYell, transform.position, Quaternion.identity);
                ObjectPooler2.SharedInstance.reuse();
            }
            if (gameObject.name == "Collect1(Clone)")
            {
                SoundManage.PlaySound("NCollect");
                movement.character.addScore(200);
                movement.character.addEnergy(40);
                Instantiate(expRed, transform.position, Quaternion.identity);
                ObjectPooler.SharedInstance.reuse();
            }
            
            
        }
        if (collision.gameObject.tag == "BlackHole" && this.gameObject.tag == "Collects")
        {
            gameObject.SetActive(false);
            ObjectPooler.SharedInstance.reuse();
            ObjectPooler2.SharedInstance.reuse();
        }
        if (collision.gameObject.tag == "BlackHole" && this.gameObject.tag == "Nocollect")
        {
            gameObject.SetActive(false);
            ObjectPoolerno.SharedInstance.reuse();
        }
        if (collision.gameObject.name == "WormHole" && this.gameObject.tag == "Collects")
        {
            gameObject.SetActive(false);
            ObjectPooler.SharedInstance.reuse();
            ObjectPooler2.SharedInstance.reuse();
        }
        if (collision.gameObject.tag == "Nocollect" && this.gameObject.tag == "Collects")
        {
            gameObject.SetActive(false);
            if (gameObject.name == "Collect2(Clone)")
            {
                Instantiate(expYell, transform.position, Quaternion.identity);
                ObjectPooler2.SharedInstance.reuse();
            }
            if (gameObject.name == "Collect1(Clone)")
            {
                Instantiate(expRed, transform.position, Quaternion.identity);
                ObjectPooler.SharedInstance.reuse();
            }
        }
        if (collision.gameObject.name == "WormHole" && this.gameObject.tag == "Nocollect")
        {
            gameObject.SetActive(false);
            ObjectPoolerno.SharedInstance.reuse();
        }
        if (collision.gameObject.name == "Player" && this.gameObject.tag == "BlackHole")
        {
            SoundManage.PlaySound("Death1");
            movement.character.Death();
        }
        if (collision.gameObject.tag == "Player" && this.gameObject.tag == "Nocollect")
        {
            Instantiate(expBlue, player.transform.position, Quaternion.identity);
            SoundManage.PlaySound("Death1");
            movement.character.Death();
        }
        if (collision.gameObject.tag == "Nocollect" && this.gameObject.tag == "Nocollect")
        {
            SoundManage.PlaySound("ExpBig");
            Instantiate(expBigRed, (collision.gameObject.transform.position + this.gameObject.transform.position) / 2, Quaternion.identity);
            collision.gameObject.SetActive(false); this.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BlackHoleCore" && this.gameObject.tag == "Nocollect")
        {
            transform.localScale = Vector3.Slerp(transform.localScale, new Vector3(0, 0), Time.deltaTime * 100f);
        }
        if (collision.gameObject.name == "WormHoleCenter" && this.gameObject.tag == "Nocollect")
        {
            transform.localScale = Vector3.Slerp(transform.localScale, new Vector3(0, 0), Time.deltaTime * 100f);
        }
    }
}
