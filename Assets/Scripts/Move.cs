using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 5f; // ความเร็วในการเคลื่อนที่

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
}
