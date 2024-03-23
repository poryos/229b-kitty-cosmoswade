using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camertagobject : MonoBehaviour
{
    public Transform target; // วัตถุที่จะติดตาม
    public float smoothSpeed = 0.125f; // ความเร็วในการเคลื่อนที่ของกล้อง
    public Vector3 offset; // ระยะห่างระหว่างกล้องกับวัตถุที่ต้องการติดตาม

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            transform.LookAt(target);
        }
    }
}
