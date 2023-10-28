using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourcePlayerManager : MonoBehaviour
{
    private static AudioSourcePlayerManager instance = null;
    [SerializeField] private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.Play();
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            return;

        } if (instance == this) return;
        Destroy(gameObject);
    }
}