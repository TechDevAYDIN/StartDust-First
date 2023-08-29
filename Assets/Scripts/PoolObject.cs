using UnityEngine;
using System.Collections;

public class PoolObject : MonoBehaviour
{
    public GameObject prefab;
    public int size;
    public static bool collision = false;
    void Start()
    {

        PoolManager.instance.CreatePool(prefab, size);
        for (int i = 0; i < size; i++)
        {
            PoolManager.instance.ReuseObject(prefab, Random.insideUnitSphere * 5, Quaternion.identity);
        }

    }
    public virtual void OnObjectReuse()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {/*
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Kazandınız");
            this.gameObject.SetActive(false);
            PoolManager.instance.ReuseObject(prefab, Random.insideUnitSphere * 5, Quaternion.identity);
        }*/
    }
    void Update()
    {
        while (collision)
        {
            collision = false;
        }
    }
    protected void Destroy()
    {
        gameObject.SetActive(false);
    }
}
