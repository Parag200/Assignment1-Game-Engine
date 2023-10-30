using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //single instance of audio manager 
    public static AudioManager Instance;

    private AudioSource audioSource;

    //allows array of sounds to be used
    [SerializeField] AudioClip[] soundFX;

    //makes sure there is only 1 instance in the scene it will not destroy itself on load
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    //get component of audio source allowing soudn to be played 
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    //this function handles sound and volume based on the array position and float value
    // using switch case to assign each sound name to its respective audio and volume
    public void playFX (string sound, float volume)
    {
        switch (sound)
        {
            case "Footsteps":
                audioSource.PlayOneShot(soundFX[0], volume);
                break;
            
            case "Jump":
                audioSource.PlayOneShot(soundFX[1], volume);
                break;
            case "Click":
                audioSource.PlayOneShot(soundFX[2], volume);
                break;
            default:
                Debug.LogError("no sound is currently playing");
                break;
        }
    }
}
