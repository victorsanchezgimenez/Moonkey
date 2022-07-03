using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameSettingsManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject gameOverMenu;
    [HideInInspector] public bool isPaused = false;
    
    void Awake() 
    {
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
    }

    public void OnClickSettingsMenuInGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
        pauseMenu.SetActive(true);
    }

    public void OnClickReturnGame()
    {
        pauseMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;

    }

    public void OnClickReestartGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void OnClickLeaveGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        
    }
}
