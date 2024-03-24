	using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Endcredit : MonoBehaviour
{
    public int score1;
    public Text scoreText1;
    private AudioSource audioSource1;
    public AudioClip itemSound1;
    void Start()
    {
        score1 = 0;
        audioSource1 = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (score1 == 30)
        {
            SceneManager.LoadScene(3);
        }
        if (score1 == 31)
        {
            SceneManager.LoadScene(3);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Items")
        {
            score1++;
            scoreText1.text = "SCORE = " + score1;
            Destroy(other.gameObject);
            audioSource1.PlayOneShot(itemSound1);

        }
    }

}