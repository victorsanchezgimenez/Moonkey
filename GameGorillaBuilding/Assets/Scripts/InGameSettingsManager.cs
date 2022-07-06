using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameSettingsManager : MonoBehaviour
{
    [Header("General Initialize GameObjects")]
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject gameOverMenu;
    [HideInInspector] public bool isPaused = false;
    [Header("Getting AudioSource Music And Mute")]
    [SerializeField] AudioSource audioSourceMusic;
    [Header("Button Sound Management")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;
    [SerializeField][Range(0f, 1f)] float soundScale = 0.8f;
    
    void Awake()
    {
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        CheckAudioSourceMusic();
    }

    private void CheckAudioSourceMusic()
    {
        if (audioSourceMusic == null)
        {
            audioSourceMusic = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioSource>();
        }
    }

    void SoundButton()
    {
        if(!audioSourceMusic.mute)
        {
            audioSource.PlayOneShot(audioClip, soundScale);
        }
    }

    public void OnClickSettingsMenuInGame()
    {
        SoundButton();
        Time.timeScale = 0f;
        isPaused = true;
        pauseMenu.SetActive(true);
    }

    public void OnClickReturnGame()
    {
        SoundButton();
        pauseMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;

    }

    public void OnClickReestartGame()
    {
        SoundButton();
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void OnClickLeaveGame()
    {
        SoundButton();
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        
    }
}
