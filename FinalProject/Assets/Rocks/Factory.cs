using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjectFactory
{
    GameObject CreateObject();
}

public class ObjectFactory : IObjectFactory
{
    private GameObject _objectPrefab;

    public ObjectFactory(GameObject objectPrefab)
    {
        _objectPrefab = objectPrefab;
    }

    public GameObject CreateObject()
    {
        return GameObject.Instantiate(_objectPrefab);
    }
}

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _objectPrefab;
    private IObjectFactory _objectFactory;

    private void Awake()
    {
        _objectFactory = new ObjectFactory(_objectPrefab);
    }

    public void SpawnObject()
    {
        GameObject newObject = _objectFactory.CreateObject();
        newObject.transform.position = transform.position;
    }
}