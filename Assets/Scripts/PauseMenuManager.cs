using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject pauseMenuUI;
    private bool isVisible = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!PlayerStats.Instance.isDead)
            {
                TogglePause();
            }
        }
    }

    public void TogglePause()
    {
        if (!isVisible)
        {
            Cursor.lockState = CursorLockMode.None;
            isVisible = true;
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            isVisible = false;
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}