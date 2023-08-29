using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BlackHole" && gameObject.tag == "Collects") 
        {
            gameObject.SetActive(false);
            ObjectPooler.SharedInstance.reuse();
        }
        if (collision.gameObject.tag == "BlackHole" && gameObject.name == "Player")
        {
            movement.character.Death();
        }
    }
}
