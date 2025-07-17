using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class RotaryObstacle : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 90;
    [SerializeField] private float _pushForce = 10;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(0, _rotationSpeed * Time.deltaTime, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Rigidbody rb = collision.collider.attachedRigidbody;
            Vector3 toPlayer = collision.transform.position - transform.position;
            toPlayer.y = 0f;

            // Direzione tangente = spinta laterale simulata dalla rotazione
            Vector3 tangent = Vector3.Cross(Vector3.up, toPlayer.normalized); // rotazione su Y

            // Applica impulso tangenziale
            rb.AddForce(tangent * _pushForce, ForceMode.Impulse);
            //rb.AddForce(Vector3.up * _pushForce, ForceMode.Impulse);
        }
    }
}
