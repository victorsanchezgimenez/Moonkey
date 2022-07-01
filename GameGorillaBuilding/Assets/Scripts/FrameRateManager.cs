using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRateManager : MonoBehaviour
{
    [Header("FPS of the game")]
    [SerializeField] int FPS = 60;

    private void Awake() 
    {    
        Application.targetFrameRate = FPS;
    }
}
