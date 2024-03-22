using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public void RestartGame()
    {
        // โหลดซีนปัจจุบันอีกครั้ง
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
