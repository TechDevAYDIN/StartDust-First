using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBounds : MonoBehaviour
{
    public GameObject Block_Text;

    void Start()
    {
        Block_Text.SetActive(false);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Block_Text.SetActive(true);
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        Block_Text.SetActive(false);
    }
}
