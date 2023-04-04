using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LutChange : MonoBehaviour
{
   
    //allows input of multiple materials
    public Material[] m_renderMaterial;

    //base number aka LUT default
    private int x = 0;

    private void Update()
    {
        //if key pressed down LUT material is equal to 1 
        if (Input.GetKeyDown(KeyCode.Z))
        {
            x = 1;
        }
        //if key pressed down LUT material is equal to 2
        else if (Input.GetKeyDown(KeyCode.X))
        {
            x = 2;
        }
        //if key pressed down LUT material is equal to 0 back to default
        else if (Input.GetKeyDown(KeyCode.C))
        {
            x = 0;
        }
    }

   
    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
      //render source texture to destination using current render material
     Graphics.Blit(source, destination, m_renderMaterial[x]);
       
    }
}

