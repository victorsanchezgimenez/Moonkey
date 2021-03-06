using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Playables;

public class MenuSceneManager : MonoBehaviour
{   
    [Header("GameObjects of Menu")]
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject mainTitle;
    [Header("Tutorials Screens GameObject")]
    [SerializeField] GameObject tutorialsScreens;
    [Header("AudioSource Component")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioManager audioManager;
    [Header("Animator Tranistion Cloud Initialize")]
    [SerializeField] Animator animatorClouds;
    [SerializeField] Button playButton;
    [SerializeField] Button settingsButton;
    public float timeWait = 15f;
    [Header("Animator Transition Settings And Menu Initialize")]
    [SerializeField] Animator animatorMenu;
    [SerializeField] Animator animatorSettings;
    [Header("Animator Transition Tutorial Initialize")]
    [SerializeField] Animator animatorTutorial;
    [SerializeField] Button playButtonTutorial;
    [Header("Animator Cinematic Timeline And FadeIn Initialize")]
    [SerializeField] PlayableDirector director;
    [SerializeField] Animator fadeAnimation;
    [Header("Button Effect Initialize")]
    [SerializeField] AudioClip clip;
    [SerializeField] AudioSource buttonAudioComponent;
    [SerializeField][Range(0f, 1f)] float volumeScale = 0.7f;
    

    //timers
    private float timeWaitCinematic = 9.0f;
    private float timeWaitFadeIn = 2.5f;
     
    void Awake()
    {
        
    }
    
    void Update() 
    {
        CheckAudioManager();
    }

    private void CheckAudioManager()
    {

        if(audioSource == null ||audioManager == null)
        {
            audioSource = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioSource>();
            audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        }
    }

    /*BUTTONS FUNCTIONS*/
    //Start
    public void OnClickPlayButton()
    {
        SoundButton();
        StartCoroutine(isTransitioningTutorial());
    }

    private void SoundButton()
    {
        if (!audioSource.mute)
        {
            buttonAudioComponent.PlayOneShot(clip, volumeScale);
        }
    }

    //Tutorial Screen 1
    public void OnClickTutorialNextOne()
    { 
        SoundButton();
        animatorTutorial.SetBool("isTutorialOne", false);
        animatorTutorial.SetBool("isTutorialTwo", true);
    }
    
    //Tutorial Screen 2
    public void OnClickTutorialNextTwo()
    {
        SoundButton();
        animatorTutorial.SetBool("isTutorialTwo", false);
        animatorTutorial.SetBool("isTutorialThree", true);  
    }
    
    //Tutorial Screen 3
    public void OnClickTutorialNextThree()
    {
        SoundButton();
        animatorTutorial.SetBool("isTutorialThree", false);
        animatorTutorial.SetBool("isTutorialFour", true);  
    }
    
    //Tutorial Screen 4
    public void OnClickTutorialNextFour()
    {
        SoundButton();
        playButtonTutorial.interactable = false;
        StartCoroutine(isTransitioningCinematic());
    }

    //Make transitions between gameobjects
    public void OnClickSettingsButton()
    {   
        SoundButton();
         
        animatorMenu.SetBool("isNotMenu", true);  
        animatorSettings.SetBool("isSettingsMenu", true);
    }

    //Make transitions between gameobjects
    public void OnClickBackSettingsMenu()
    {
        SoundButton();
        
        animatorMenu.SetBool("isNotMenu", false);
        animatorSettings.SetBool("isSettingsMenu", false);   
    }

    //OFF Button Music
    public void OnClickMuteMusic()
    {
        SoundButton();
        
        audioManager.MuteMusic(true);
    }

    //ON Button Music
    public void OnClickActiveMusic()
    {
        SoundButton();
        
        audioManager.MuteMusic(false);
    }



    //Clouds transition start tutorial
    IEnumerator isTransitioningTutorial()
    {
        playButton.interactable = false;
        settingsButton.interactable = false;
        StartCloudEffect();
        yield return new WaitForSeconds(timeWait);
        EndCloudEffect();
        ActiveTutorial();
        mainTitle.SetActive(false);
        mainMenu.SetActive(false);
        

    }

    //Tutorial start transition
    private void ActiveTutorial()
    {
        animatorTutorial.SetBool("isTutorialOne", true);
    }


    //Clouds Transition ON
    private void StartCloudEffect()
    {
        animatorClouds.SetBool("isPlaying", true);
    }

    //Clouds Transition OFF
    private void EndCloudEffect()
    {
        animatorClouds.SetBool("isPlaying", false);
    }

    //Cinematic transition
    IEnumerator isTransitioningCinematic()
    {
        StartCloudEffect();
        yield return new WaitForSeconds(timeWait);
        tutorialsScreens.SetActive(false);
        EndCloudEffect();
        //Timeline start here
        director.Play();
        yield return new WaitForSeconds(timeWaitCinematic);
        //Start Fade
        fadeAnimation.SetBool("FadeIn", true);
        yield return new WaitForSecondsRealtime(timeWaitFadeIn);
        //Charge Game Level
        SceneManager.LoadScene(1);
    }
}
