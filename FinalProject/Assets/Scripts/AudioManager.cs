using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private AudioSource audioSource;
    [SerializeField] AudioClip[] soundFX;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

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
