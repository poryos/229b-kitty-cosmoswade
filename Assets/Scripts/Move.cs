using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
   public float moveSpeed = 5f; // ความเร็วในการเคลื่อนที่
    public float tiltAngle = 15f; // มุมที่วัตถุจะเอียง
    public GameObject bulletPrefab; // โปรเจคของกระสุน
    public Transform bulletSpawnPoint; // จุดเริ่มต้นของกระสุน
    public float bulletSpeed = 10f; // ความเร็วของกระสุน

    void Start()
    {
        // เริ่มการเคลื่อนที่ทันทีเมื่อเกมเริ่มต้น
        MoveForward();
    }

    void MoveForward()
    {
        // เคลื่อนที่วัตถุไปทางบวกของแกน z (หน้า) โดยใช้ความเร็ว moveSpeed
        Vector3 movement = new Vector3(0f, 0f, 1f) * moveSpeed * Time.deltaTime;
        transform.Translate(movement, Space.World); // เคลื่อนที่โดยใช้พื้นที่โลก (World Space)

        // เรียกเมธอดนี้ใหม่ในทุกๆ frame เพื่อให้วัตถุเคลื่อนที่ไปหน้าเรื่อยๆ
        Invoke("MoveForward", Time.deltaTime);
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // รับค่าการกดปุ่มเคลื่อนที่ซ้าย-ขวา (A และ D หรือ LeftArrow และ RightArrow)

        // เคลื่อนที่วัตถุไปทางซ้ายหรือขวาโดยใช้ค่า horizontalInput
        Vector3 sideMovement = new Vector3(horizontalInput, 0f, 0f) * moveSpeed * Time.deltaTime;
        transform.Translate(sideMovement, Space.World); // เคลื่อนที่โดยใช้พื้นที่โลก (World Space)

        // คำนวณมุมการเอียงของวัตถุตามการเคลื่อนที่ซ้ายขวา
        float tiltAroundZ = -horizontalInput * tiltAngle;
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, tiltAroundZ);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f); // ใช้ Quaternion.Slerp เพื่อให้การเอียงเป็นอาสมีที่นุ่มนวล

        // การยิงกระสุนเมื่อกดปุ่ม Spacebar
        if (Input.GetKeyDown(KeyCode.Space))
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
