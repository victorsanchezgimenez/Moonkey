using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ProgressBarScore : MonoBehaviour
{
    [Header("General Settings")]
    [SerializeField] float speedBar = 0.01f;
    [Header("Getting necessary GameObjects")]
    [SerializeField] Slider progressBar;
    [SerializeField] TextMeshProUGUI numberProgressBar; 

    PlayerStats playerStats;

    void Update()
    {
        RunningBar();
        UpdateNumberProgressBar();

    }

    //upgrade current % of bar
    private void UpdateNumberProgressBar()
    {
        numberProgressBar.text = Mathf.Abs((int)progressBar.value).ToString() + " %";
    }

    private void RunningBar()
    {
        progressBar.value += speedBar;
    }

    private void FinishGame()
    {
        if(progressBar.value == progressBar.maxValue)
        {

        }

    }

    private void ResetGame()
    {
        
    }
}
