using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public int score;
    public Text scoreText;
    private AudioSource audioSource;
    public AudioClip itemSound;
    void Start()
    {
        score = 00;
        audioSource = GetComponent<AudioSource>();
    }
    void FixedUpdate()
    {
        if (score == 50)
        {
            SceneManager.LoadScene(2);
        }
		if (score == 51)
        {
            SceneManager.LoadScene(2);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Items")
        {
            score++;
            scoreText.text = "SCORE = " + score;
            Destroy(other.gameObject);
            audioSource.PlayOneShot(itemSound);
            
        }
    }
    
}
