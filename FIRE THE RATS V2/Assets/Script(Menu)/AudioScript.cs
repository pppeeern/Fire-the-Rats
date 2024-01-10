using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource BGM;
    [SerializeField] AudioSource SFX;

    [Header("Audio Clip")]
    public AudioClip background;
    public AudioClip click;

    public static AudioScript instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
        
    }

    private void Start()
    {
        BGM.clip = background;
        BGM.Play();
    }

    public void PlaySFX(AudioClip clip) {
        SFX.PlayOneShot(clip);
    }
}
