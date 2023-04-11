using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool Paused = false;
    public GameObject pauseMenuUi;
    [SerializeField] FirstPersonLook FPLook;

    float tempSensitivity;

    private void Start()
    {
        tempSensitivity = FPLook.sensitivity;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        FPLook.sensitivity = tempSensitivity;
    }

    public void Pause()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        FPLook.sensitivity = 0f;
    }
    public void quitGame()
    {
        Debug.Log("quiting game");
        Application.Quit();

    }

    public void loadlevel()
    {
        Debug.Log("level Loading");
        SceneManager.LoadScene("mainMenu");
    }

    public void BookResume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void BookPause()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
}
