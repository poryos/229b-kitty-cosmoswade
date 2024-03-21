using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // ความเร็วในการเคลื่อนที่ของเครื่องบิน
    public float rotationSpeed = 100f; // ความเร็วในการหมุนของเครื่องบิน
    public float maxPitchAngle = 90f; // มุมที่เครื่องบินสามารถเอียงได้สูงสุด
    public float minPitchAngle = -90f; // มุมที่เครื่องบินสามารถเอียงได้ต่ำสุด

    public GameObject bulletPrefab; // โปรเจคของกระสุน
    public Transform bulletSpawnPoint; // จุดเริ่มต้นของกระสุน
    public float bulletSpeed = 10f; // ความเร็วของกระสุน

    void Update()
    {
        // การเคลื่อนที่ของเครื่องบินโดยใช้ปุ่ม W A S D
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;
        transform.Translate(movement, Space.Self);

        // การหมุนมุมมองด้วยเมาส์
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        float pitchAngle = Mathf.Clamp(transform.eulerAngles.x - mouseY * rotationSpeed * Time.deltaTime, minPitchAngle, maxPitchAngle);
        transform.rotation = Quaternion.Euler(pitchAngle, transform.eulerAngles.y + mouseX * rotationSpeed * Time.deltaTime, 0f);

        // การยิงกระสุนเมื่อกดปุ่ม Mouse
        if (Input.GetButtonDown("Fire1")) // ปุ่ม Fire1 คือปุ่ม Mouse ซ้าย
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // สร้างกระสุนด้วย GameObject ที่ระบุ
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        // เคลื่อนที่กระสุนไปทางบวกของแกน z (หน้า) โดยใช้ความเร็วของกระสุน
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;
    }
}