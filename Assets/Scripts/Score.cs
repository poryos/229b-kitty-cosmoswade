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
        score = 0;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
