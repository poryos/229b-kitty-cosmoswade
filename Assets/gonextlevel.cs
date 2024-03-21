using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gonextlevel : MonoBehaviour
{
    public string Level2;

    public void OnTriggerEnter(Collider other)
    {
        if (!string.IsNullOrEmpty(Level2))
        {
            // ‚À≈¥©“°∂—¥‰ª
            SceneManager.LoadScene(Level2);
        }
        else
        {
            Debug.LogError("Next scene name is empty or null. Please assign a valid scene name.");
        }
    }
}