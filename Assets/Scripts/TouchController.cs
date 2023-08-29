using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEditor;
using UnityEngine;

public class TouchController : MonoBehaviour
{

    private Rigidbody2D rb;
    private SpringJoint2D grappler;
    
    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           

        }
    }

/*
   void TouchMove()
    {
        
        if (Input.touchCount > 0)
        {
            // The screen has been touched so store the touch
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved && touch.phase != TouchPhase.Stationary)
            {
                // If the finger is on the screen, move the object smoothly to the touch position
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0.0f));
                transform.position = Vector3.Lerp(transform.position, new Vector3(touchPosition.x, touchPosition.y + .5f, -.02f), Time.deltaTime * 10f);
            }

        }
    }
   */ 
}
