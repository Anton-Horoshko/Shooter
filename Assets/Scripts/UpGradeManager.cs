using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpGrade : MonoBehaviour
{
    public GameObject upgradeUI;
    private bool IsVisible = false;

    void Update()
    {

    }

    public void ToggleUpgrade()
    {
        if (!IsVisible)
        {
            Cursor.lockState = CursorLockMode.None;
            IsVisible = true;
            upgradeUI.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            IsVisible = false;
            upgradeUI.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
