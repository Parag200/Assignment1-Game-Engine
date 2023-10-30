using System;
using UnityEngine;

public class ObjectSpawnerFactory : MonoBehaviour
{
    //array of game objects incase we want to spawn mulitple different objects 
    public GameObject[] Prefabs;


    public GameObject Spawn(int type)
    {

        //instatiate prefab of certain array type with its position and rotation
        GameObject instance = Instantiate(Prefabs[type]);
        instance.transform.position = transform.position;
        instance.transform.rotation = transform.rotation;
        return instance;
    }

    public void Start()
    {
        //spawning object in the 0 position array 
        Spawn(0);
    }
}