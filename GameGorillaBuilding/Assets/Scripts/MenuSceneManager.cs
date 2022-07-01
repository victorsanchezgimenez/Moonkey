using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneManager : MonoBehaviour
{   
    [Header("GameObjects of Menu")]
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject settingsMenu;
    [Header("AudioSource Component")]
    [SerializeField] AudioManager audioManager;

     
    void Awake()
    {
        settingsMenu.SetActive(false);
        CheckAudioManager();
    }

    private void CheckAudioManager()
    {
        if (audioManager == null)
        {
            audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        }
    }

    public void OnClickPlayButton()
    {
        //Transition effect TODO
        SceneManager.LoadScene(1);

    }
    
    public void OnClickSettingsButton()
    {
        //Transition effect TODO

        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void OnClickMuteMusic()
    {
        audioManager.MuteMusic(true);
    }

    
    public void OnClickActiveMusic()
    {
        audioManager.MuteMusic(false);
    }


    public void OnClickBackSettingsMenu()
    {
        //TransitionEffect TODO

        settingsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

}
