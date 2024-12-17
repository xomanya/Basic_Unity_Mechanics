using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceMovement : MonoBehaviour
{
    public float force = 5f;
    public float rotationSpeed = 100f;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float xDirection = 0;
        float zDirection = 0;

        // Movement foeward/backforward
        if (Input.GetKey(KeyCode.W))
        {
            zDirection = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            zDirection = -1;
        }

        // Movement to sides
        if (Input.GetKey(KeyCode.A))
        {
            xDirection = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            xDirection = 1;
        }
        
        // Rotation
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(-Vector3.up * rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
        
        Vector3 direction = new Vector3(xDirection, 0, zDirection).normalized * force;
        _rigidbody.AddForce(transform.TransformDirection(direction));
    }
}
