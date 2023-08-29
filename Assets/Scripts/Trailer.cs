using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trailer : MonoBehaviour
{
    [SerializeField] private Transform Playerball = null;

    void FixedUpdate()
    {
        float x = Playerball.transform.position.x;
        float y = Playerball.transform.position.y;
        transform.position = new Vector2(x, y);
    }
}
