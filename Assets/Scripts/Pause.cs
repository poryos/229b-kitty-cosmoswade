using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu; // ระบุ Canvas ของเมนู Pause ที่คุณสร้าง

    private bool isPaused = false;

    void Start()
    {
        pauseMenu.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f; // หยุดเวลาในเกม
            pauseMenu.SetActive(true); // เปิดเมนู Pause
        }
        else
        {
            Time.timeScale = 1f; // เริ่มเวลาในเกมอีกครั้ง
            pauseMenu.SetActive(false); // ปิดเมนู Pause
        }
    }
}
