using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class ProgressBarScore : MonoBehaviour
{
    [Header("General Settings")]
    [SerializeField] float speedBar = 0.01f;
    [Header("Getting necessary GameObjects")]
    [SerializeField] Slider progressBar;
    [SerializeField] TextMeshProUGUI numberProgressBar; 
    [SerializeField] InGameSettingsManager pauseActive;
    
    [Header("Getting Spawners to Increase Difficult")]
    [SerializeField] GameObject[] enemyFallSpawner;
    [SerializeField] GameObject[] enemyBirdSpawner;
    [SerializeField] GameObject[] enemyScaffoldSpawner;
    [SerializeField] GameObject[] healthSpawner;

    [Header("Getting Player GameObject")]
    [SerializeField] GameObject player;

    [Header("Components Cutscene And Variables")]
    [SerializeField] Joystick joystick;
    [SerializeField] Animator fadeIn;
    [SerializeField] float waitTime = 2.5f;
    [SerializeField] float speedLeaveScenePlayer = 7f;
    

    //Difficults trigger one time
    private bool difOne = false, difTwo = false, difThree = false, difFour = false;

    void Update()
    {
        RunningBar();
        UpdateNumberProgressBar();
        DifficultLevels();
        FinishGame();

    }

    //upgrade current % of bar
    private void UpdateNumberProgressBar()
    {
        numberProgressBar.text = Mathf.Abs((int)progressBar.value).ToString() + " %";
    }

    //Bar continue Value
    private void RunningBar()
    {
        if(!pauseActive.isPaused)
            progressBar.value += speedBar;
    }

    private void FinishGame()
    {
        if(progressBar.value == progressBar.maxValue)
        {
            StartCoroutine(EndGameTransition());
        }

    }

    IEnumerator EndGameTransition()
    {
            //Disable character collisions and controller
            player.GetComponent<CapsuleCollider>().enabled = false;
            joystick.enabled = false;
            //Move character
            player.transform.Translate(0, 0, speedLeaveScenePlayer * Time.deltaTime);
            //Start fade animation
            fadeIn.SetBool("FadeOut", false);
            yield return new WaitForSeconds(waitTime);
            //Load Scene Endgame
            SceneManager.LoadScene(2);
    }

    //Level difficulties
    private void DifficultLevels()
    {
         
        if(progressBar.value <= 25f && !difOne)
        {
            //Plant Spawner
            UpgradeStatsDifficult(enemyFallSpawner, 0, 10, 5, 1f);
            //Eagle Spawner
            UpgradeStatsDifficult(enemyBirdSpawner, 0, 15, 5, 1f);
            //Scaffold Spawner
            UpgradeStatsDifficult(enemyScaffoldSpawner, 0, 20, 5, 1f);
            //Health Spawner
            UpgradeStatsDifficult(healthSpawner, 0, 40, 5, 1f);
            difOne = true;
        }

        else if(progressBar.value > 25f && progressBar.value < 50f && !difTwo)
        {
            //Plant Spawner
            UpgradeStatsDifficult(enemyFallSpawner, 0, 8, 5, 1f);
            //Eagle Spawner
            UpgradeStatsDifficult(enemyBirdSpawner, 0, 12, 5, 1f);
            //Scaffold Spawner
            UpgradeStatsDifficult(enemyScaffoldSpawner, 0, 15, 5, 1f);
            //Health Spawner
            UpgradeStatsDifficult(healthSpawner, 0, 35, 5, 1f);
            difTwo = true;
        }

        else if(progressBar.value > 50f && progressBar.value < 75f && !difThree)
        {
            //Plant Spawner
            UpgradeStatsDifficult(enemyFallSpawner, 0, 7, 5, 1f);
            //Eagle Spawner
            UpgradeStatsDifficult(enemyBirdSpawner, 0, 9, 5, 1f);
            //Scaffold Spawner
            UpgradeStatsDifficult(enemyScaffoldSpawner, 0, 11, 5, 1f);
            //Health Spawner
            UpgradeStatsDifficult(healthSpawner, 0, 35, 5, 1f);
            difThree = true;
        }

        else if(progressBar.value > 75f && !difFour)
        {
            //Plant Spawner
            UpgradeStatsDifficult(enemyFallSpawner, 0, 6, 3, 1f);
            //Eagle Spawner
            UpgradeStatsDifficult(enemyBirdSpawner, 0, 8, 5, 1f);
            //Scaffold Spawner
            UpgradeStatsDifficult(enemyScaffoldSpawner, 0, 10, 5, 1f);
            //Health Spawner
            UpgradeStatsDifficult(healthSpawner, 0, 30, 5, 1f);
            difFour = true;
        }
    }

    //Function to change parameters
    public void UpgradeStatsDifficult(GameObject[] spawner, int min, int max, int actual, float timeSpawner)
    {
        foreach(GameObject enemyFalling in spawner)
            {
                SpawnGameObjectFalling enemyFallScript;
                enemyFallScript = enemyFalling.GetComponent<SpawnGameObjectFalling>();
                enemyFallScript.minProbRange = min;
                enemyFallScript.maxProbRange = max;
                enemyFallScript.actualProb = actual;
                enemyFallScript.respawnTime = timeSpawner;
            }

    }
}
