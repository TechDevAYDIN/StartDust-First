using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    Vector2 pos;
    Transform cam;
    void Start()
    {
        ObjectPoolerBH.SharedInstance.reuse();
    }
    
    // Update is called once per frame
    void Update()
    {
        cam = Camera.main.transform;
        pos = gameObject.transform.position;
        if (pos.x < cam.position.x - 110 || pos.x > cam.position.x + 110 || pos.y < cam.position.y - 110 || pos.y > cam.position.y + 110)
        {
            gameObject.SetActive(false);
            ObjectPoolerBH.SharedInstance.reuse();
            gameObject.GetComponent<Rigidbody2D>().AddTorque(-20000000);

        }
    }
}
