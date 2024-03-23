using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{

    [SerializeField] Rigidbody rb;
    const float G = 6.674f;

    public float attractionRange = 10f;

    public static List<Attractor> Attractors;

    private void FixedUpdate()
    {
        foreach (var attractor in Attractors)
        {
            if (attractor != this)
            {
                float distance = Vector3.Distance(transform.position, attractor.transform.position);

                if (distance <= attractionRange)
                {
                    Attract(attractor);
                }
            }
        }
    }

    private void OnEnable()
    {
        if (Attractors == null)
        {
            Attractors = new List<Attractor>();
        }
        Attractors.Add(this);
    }

    private void OnDestroy()
    {
        Attractors.Remove(this);
    }

    void Attract(Attractor other)
    {
        Rigidbody rb2 = other.rb;

        Vector3 direction = rb.position - rb2.position;
        float distance = direction.magnitude;

        
        if (distance == 0f)
        {
            return;
        }

        float forceMagnitude = G * (rb.mass * rb2.mass) / (distance * distance);
        Vector3 finalForce = direction.normalized * forceMagnitude;

        
        rb2.MovePosition(rb2.position + finalForce * Time.fixedDeltaTime);
    }
}
