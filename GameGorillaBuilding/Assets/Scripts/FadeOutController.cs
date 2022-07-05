using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutController : MonoBehaviour
{
    [Header("Getting Animator Component")]
    [SerializeField] Animator animationFade;
    
    void Awake() 
    {
        animationFade.SetBool("FadeOut", true);
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
