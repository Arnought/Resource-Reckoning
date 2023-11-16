using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioSourcePlayerManager : MonoBehaviour
{
    public AudioClip mainMenuBGM;
    public AudioClip howToPlayBGM;
    public AudioClip gameBGM;
    public AudioClip questCompleteBGM;

    private static AudioSourcePlayerManager instance = null;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlaySceneBGM();
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        if (instance == this) return;
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

        if (SceneManager.GetActiveScene().name == "MainMenu" && audioSource.clip != mainMenuBGM)
        {
            audioSource.clip = mainMenuBGM;
            PlaySceneBGM();
        }
        else if (SceneManager.GetActiveScene().name == "HowToPlay" && audioSource.clip != howToPlayBGM)
        {
            audioSource.clip = howToPlayBGM;
            PlaySceneBGM();
        }
        else if (SceneManager.GetActiveScene().name == "GameScene" && audioSource.clip != gameBGM)
        {
            audioSource.clip = gameBGM;
            PlaySceneBGM();
        }
        else if (SceneManager.GetActiveScene().name == "Quest Complete" && audioSource.clip != questCompleteBGM)
        {
            audioSource.clip = questCompleteBGM;
            PlaySceneBGM();
        }
    }

    void PlaySceneBGM()
    {
        audioSource.Stop();
        audioSource.Play();
    }
}