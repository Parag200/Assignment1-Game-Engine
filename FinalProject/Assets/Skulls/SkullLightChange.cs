using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullLightChange : MonoBehaviour
{

    
    public Material[] mat;
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = mat[0];
    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("2"))
        {
            rend.sharedMaterial = mat[1];
        }

        else if (Input.GetKeyUp("2"))
        {
            rend.sharedMaterial = mat[0];
        }

        else if (Input.GetKeyDown("3"))
        {
            rend.sharedMaterial = mat[2];
        }

        else if (Input.GetKeyUp("3"))
        {
            rend.sharedMaterial = mat[0];
        }

        else if (Input.GetKeyDown("4"))
        {
            rend.sharedMaterial = mat[1];
            rend.sharedMaterial = mat[2];
        }

        else if (Input.GetKeyUp("4"))
        {
            rend.sharedMaterial = mat[0];
        }

        else if (Input.GetKeyDown("5"))
        {
            rend.sharedMaterial = mat[3];
        }

        else if (Input.GetKeyUp("5"))
        {
            rend.sharedMaterial = mat[0];
        }
    }
}
