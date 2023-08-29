using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler SharedInstance;

    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;
    public int moveSpeed = 10;
    float x;
    float y;
    Transform cam;

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
        reuse();
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
        GameObject clone = ObjectPooler.SharedInstance.GetPooledObject();
        if (clone != null)
        {
            x = Random.Range(cam.position.x - 32, cam.position.x + 32);
            
            y = Random.Range(cam.position.y - 20, cam.position.y + 20);
            while(x > cam.position.x - 20 && x < cam.position.x + 20 && y > cam.position.y - 15 && y < cam.position.y + 15)
            {
                x = Random.Range(cam.position.x - 30, cam.position.x + 30);
                y = Random.Range(cam.position.y - 20, cam.position.y + 20);
            }
            clone.transform.position = new Vector3(x, y);
            clone.transform.rotation = Quaternion.identity;
            
            clone.SetActive(true);
            clone.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-moveSpeed, moveSpeed), Random.Range(-moveSpeed, moveSpeed)), ForceMode2D.Impulse);
            clone.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-400,400), ForceMode2D.Force);
        }
    }
}
