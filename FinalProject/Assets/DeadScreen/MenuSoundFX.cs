using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSoundFX : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Sound()
    {
        AudioManager.Instance.playFX("Click", 1f);
    }
}
