using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LutChange : MonoBehaviour
{
   
    //public Shader awesomeShader = null;
    public Material[] m_renderMaterial;
    private int x = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            x = 1;
        }

        else if (Input.GetKeyDown(KeyCode.X))
        {
            x = 2;
        }

        else if (Input.GetKeyDown(KeyCode.C))
        {
            x = 0;
        }
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {

     Graphics.Blit(source, destination, m_renderMaterial[x]);
       
    }
}

