using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// handles events pertaining to the game
public class GameController : MonoBehaviour
{
    private float time;
    private bool paused;

    [SerializeField] private Canvas pauseCanvas;
    [SerializeField] private Canvas winCanvas;
    [SerializeField] private Canvas loseCanvas;


    private void Awake()
    {
        pauseCanvas.enabled = false;
        winCanvas.enabled = false;
        loseCanvas.enabled = false;
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                paused = false;
                UnPause();
            }
            else
            {
                paused = true;
                Pause();
            }
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        pauseCanvas.enabled = true;
    }

    public void UnPause()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        pauseCanvas.enabled = false;
    }

    public void Win()
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        winCanvas.enabled = true;
    }
    public void Lose()
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        loseCanvas.enabled = true;
    }

    public float GetTime()
    {
        return time;
    }


    // completely resets the scene since nothing depends on stats
    public void ReloadThisScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToScene(string x)
    {
        SceneManager.LoadScene(x);
    }

}
