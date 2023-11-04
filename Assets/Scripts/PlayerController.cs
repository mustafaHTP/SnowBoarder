using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Surface Effecor")]
    [SerializeField] private SurfaceEffector2D surfaceEffector;
    [SerializeField] private float normalSpeed;
    [SerializeField] private float boostSpeed;

    [Header("Rotation Settings")]
    [Space(5)]
    [SerializeField] private float torqueForce;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        RotatePlayer();

        if (Input.GetKey(KeyCode.Space))
        {
            surfaceEffector.speed = boostSpeed;
        }
        else
        {
            surfaceEffector.speed = normalSpeed;
        }
    }

    private void RotatePlayer()
    {
        float rotationInput = Input.GetAxis("Horizontal");
        _rigidbody.AddTorque(-rotationInput * torqueForce * Time.fixedDeltaTime);
    }
}
