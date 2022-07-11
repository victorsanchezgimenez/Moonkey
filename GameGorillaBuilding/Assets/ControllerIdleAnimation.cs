using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerIdleAnimation : MonoBehaviour
{
    [Header("Getting Animator Component")]
    [SerializeField] Animator animator;
    [Header("Getting Fade Component")]
    [SerializeField] Animator animatorFade;
    [Header("Getting Audiomanager Mute or Not")]
    [SerializeField] AudioSource audioSourceMusic;
    [Header("Getting Sounds Player Components")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;
    [SerializeField] float soundScale = 0.8f;

    void Awake() 
    {
        if(audioSourceMusic == null)
        {
            audioSourceMusic = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioSource>();
        }
    }
    void Start() 
    {
        StartCoroutine(IdleAndSoundPlayer());
    }

    IEnumerator IdleAndSoundPlayer()
    {
        yield return new WaitForSeconds(6.2f);
        animator.SetBool("FinalScene", true);
        yield return new WaitForSeconds(6f);
        if(!audioSourceMusic.mute)
        {
            audioSource.PlayOneShot(audioClip, soundScale);
        }
        yield return new WaitForSeconds(2f);
        animatorFade.SetBool("FadeIn", true);
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(0);


    }
}
