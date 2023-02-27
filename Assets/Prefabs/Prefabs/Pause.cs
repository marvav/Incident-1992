using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pausePlane;
    public bool isPaused;
    void Start()
    {
        
    }

    public void Restart()
    {
        Time.timeScale = 1;
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pausePlane.SetActive(false);
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused == false)
            {
                Time.timeScale = 0;
                isPaused = true;
                pausePlane.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                return;
            }
            if (isPaused == true)
            {
                Time.timeScale = 1;
                isPaused = false;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                pausePlane.SetActive(false);
            }
        }
    }
}
