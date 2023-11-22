using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling instance;

    public List<GameObject> pooledObjects = new List<GameObject>();
    private int amountToPool = 3;

    [SerializeField] private GameObject poolingObject;

    private void Awake()
    {
        if(instance == null ) instance = this;

    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < amountToPool; i++) 
        {
            GameObject obj = Instantiate(poolingObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0;i < pooledObjects.Count;i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];

            }
        }

        return null; 
    }
}
