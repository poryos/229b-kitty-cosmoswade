using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartUI : MonoBehaviour
{
    public Rigidbody2D objectRigidbody;
    public Rigidbody2D objectRigidbody2;

    public Vector2 forceDirection;
    public Vector2 forceDirection2;
    public float forceMagnitude;
    public float forceMagnitude2;

    
    
    public void PlayGame() 
    {
        objectRigidbody.AddForce(forceDirection * forceMagnitude, ForceMode2D.Impulse);
        
        objectRigidbody2.AddForce(forceDirection2 * forceMagnitude2, ForceMode2D.Impulse);
    
        StartCoroutine(LoadSceneWithDelay(1));
    }
    private IEnumerator LoadSceneWithDelay(int sceneIndex)
    {
        yield return new WaitForSeconds(2f);
        
        SceneManager.LoadSceneAsync(sceneIndex);
        
    }
}
