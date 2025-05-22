using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpGrade : MonoBehaviour
{
    public GameObject pauseUI;
    private bool IsVisible = false;

    void Update()
    {

    }

    public void TogglePause()
    {
        if (!IsVisible)
        {
            Cursor.lockState = CursorLockMode.None;
            IsVisible = true;
            pauseUI.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            IsVisible = false;
            pauseUI.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
