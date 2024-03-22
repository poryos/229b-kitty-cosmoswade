using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeObjectOnCollision : MonoBehaviour
{
    public GameObject newObjectPrefab; // วัตถุใหม่ที่จะแทนที่วัตถุเก่า
    public bool destroyOldObject = true; // ตัวแปรที่บอกว่าจะทำลายวัตถุเก่าหรือไม่

    private void OnCollisionEnter(Collision collision)
    {
        // ตรวจสอบว่าวัตถุที่ชนมี Tag ที่เราต้องการหรือไม่
        if (collision.gameObject.CompareTag("CollisionObjectTag"))
        {
            // สร้างวัตถุใหม่
            GameObject newObject = Instantiate(newObjectPrefab, transform.position, transform.rotation);

            // ทำลายวัตถุเก่า (ถ้าตั้งค่าให้ทำ)
            if (destroyOldObject)
            {
                Destroy(gameObject);
            }
        }
    }
}