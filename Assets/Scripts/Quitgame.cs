using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quitgame : MonoBehaviour
{
	public string Credit;

    public void QuitGame()
    {
        SceneManager.LoadScene(Credit);
    }
}
