using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceMovement : MonoBehaviour
{
    public float force = 5f;
    public float rotationSpeed = 100f;
    private Rigidbody _rigidbody;
    private Animator _animator;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float xDirection = 0;
        float zDirection = 0;

        if (Input.GetKey(KeyCode.W))
        {
            zDirection = 1;
            _animator.SetBool("IsWalk", true);
            
        }

        if (Input.GetKey(KeyCode.S))
        {
            zDirection = -1;
            _animator.SetBool("IsWalk", true);
        }

        if (Input.GetKey(KeyCode.A))
        {
            xDirection = -1;
            _animator.SetBool("IsWalk", true);
            transform.Rotate(-Vector3.up * rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            xDirection = 1;
            _animator.SetBool("IsWalk", true);
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
        _animator.SetBool("IsWalk", false);
        Vector3 direction = new Vector3(xDirection, 0, zDirection) * force;
        _rigidbody.AddForce(direction);
    }
}
