using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{

    public GameObject[] pointLight;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
           pointLight[0].SetActive(false);
           pointLight[1].SetActive(false);
           pointLight[2].SetActive(false);
           pointLight[3].SetActive(false);
        }

        else if (Input.GetKeyUp("1"))
        {
            pointLight[0].SetActive(true);
            pointLight[1].SetActive(true);
            pointLight[2].SetActive(true);
            pointLight[3].SetActive(true);
            Debug.Log("Released1");
        }

     
    }
}
