using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolerno : MonoBehaviour
{
    public static ObjectPoolerno SharedInstance;

    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;
    public int moveSpeed = 2500;
    float x;
    float y;
    Transform cam;
    Vector3 actualScale;

    void Awake()
    {
        SharedInstance = this;
    }
    void Start()
    {
        cam = Camera.main.transform;
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(objectToPool);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
        actualScale = ObjectPoolerno.SharedInstance.GetPooledObject().transform.localScale;
        //reuse();
    }
    public GameObject GetPooledObject()
    {
        //1
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            //2
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        //3   
        return null;
    }
    public void reuse()
    {
        GameObject clone2 = ObjectPoolerno.SharedInstance.GetPooledObject();
        if (clone2 != null)
        {
            x = Random.Range(cam.position.x - 40, cam.position.x + 40);
            
            y = Random.Range(cam.position.y - 30, cam.position.y + 30);
            while(x > cam.position.x - 20 && x < cam.position.x + 20 && y > cam.position.y - 15 && y < cam.position.y + 15)
            {
                x = Random.Range(cam.position.x - 40, cam.position.x + 40);
                y = Random.Range(cam.position.y - 30, cam.position.y + 30);
            }
            clone2.transform.position = new Vector3(x, y);
            clone2.transform.rotation = Quaternion.identity;

            clone2.transform.localScale = actualScale;
            clone2.SetActive(true);
            clone2.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-moveSpeed, moveSpeed), Random.Range(-moveSpeed, moveSpeed)), ForceMode2D.Impulse);
            clone2.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-25000,25000), ForceMode2D.Force);
        }
    }
}
