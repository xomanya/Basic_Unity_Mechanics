using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformMovement : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 100f;
    
    void Update()
    {
        float xDirection = 0;
        float zDirection = 0;

        // Movement forward/backward
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
        
        Vector3 direction = new Vector3(xDirection, 0, zDirection) * (speed * Time.deltaTime);
        transform.Translate(direction);
    }
}
