using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolerBH : MonoBehaviour
{
    public static ObjectPoolerBH SharedInstance;

    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;
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
        GameObject clone = ObjectPoolerBH.SharedInstance.GetPooledObject();
        if (clone != null)
        {
            x = Random.Range(cam.position.x - 100, cam.position.x + 100);

            y = Random.Range(cam.position.y - 100, cam.position.y + 100);
            while (x > cam.position.x - 30 && x < cam.position.x + 30 && y > cam.position.y - 20 && y < cam.position.y + 20)
            {
                x = Random.Range(cam.position.x - 100, cam.position.x + 100);
                y = Random.Range(cam.position.y - 100, cam.position.y + 100);
            }
            clone.transform.position = new Vector3(x, y);
            clone.transform.rotation = Quaternion.identity;

            clone.SetActive(true);
            clone.GetComponent<Rigidbody2D>().AddTorque(-1200000);
        }
    }
}
