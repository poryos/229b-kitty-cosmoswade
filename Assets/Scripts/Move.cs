using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneMovement : MonoBehaviour
{
    public float moveSpeed = 500f; 
    public float rotationSpeed = 100f; 
    public float maxPitchAngle = 90f; 
    public float minPitchAngle = -90f; 

    public GameObject bulletPrefab; 
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 10f;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;
        transform.Translate(movement, Space.Self);

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        float pitchAngle = Mathf.Clamp(transform.eulerAngles.x - mouseY * rotationSpeed * Time.deltaTime, minPitchAngle, maxPitchAngle);
        transform.rotation = Quaternion.Euler(pitchAngle, transform.eulerAngles.y + mouseX * rotationSpeed * Time.deltaTime, 0f);

        if (Input.GetButtonDown("Fire1")) 
        {
            Shoot();
        }
    }
	 IEnumerator ResetSpeed()
	{
  	   yield return new WaitForSeconds(5f); 
   	   moveSpeed -= 500f; 
	}

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;
    }
}