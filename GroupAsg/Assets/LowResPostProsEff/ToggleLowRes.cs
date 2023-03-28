using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLowRes : MonoBehaviour
{

    public RenderTexture targetTexture;
    public RenderTexture lowRes;

    private Camera cam;

    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    // Start is called before the first frame update
    void Start()
    {
        targetTexture = null;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            cam.targetTexture = lowRes;
        }

        

    }

    
}
