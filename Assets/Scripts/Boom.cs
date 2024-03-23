using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeObjectOnCollision : MonoBehaviour
{
    public GameObject newObjectPrefab; 
    public GameObject restartMenu;
    public bool destroyOldObject = true; 

    void Start()
    {
        restartMenu.SetActive(false);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("CollisionObjectTag"))
        {
            
            GameObject newObject = Instantiate(newObjectPrefab, transform.position, transform.rotation);

            
            if (destroyOldObject)
            {
                Destroy(gameObject);
                restartMenu.SetActive(true);
            }
            
        }
    }
}