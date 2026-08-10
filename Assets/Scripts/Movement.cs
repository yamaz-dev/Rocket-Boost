using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField]
    InputAction thrust;

    [SerializeField]
    InputAction rotation;

    [SerializeField]
    Rigidbody rb;

    [SerializeField]
    float thrustStrength = 100f;

    [SerializeField]
    float rotationStrenght = 100f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        thrust.Enable();
        rotation.Enable();
    }

    private void FixedUpdate()
    {
        ProssesThrust();
        ProssesRotation();
    }

    private void ProssesThrust()
    {
        if (thrust.IsPressed())
        {
            rb.AddRelativeForce(Vector3.up * thrustStrength * Time.fixedDeltaTime);
        }
    }

    private void ProssesRotation()
    {
        float rotationInput = rotation.ReadValue<float>();
        if (rotationInput < 0)
        {
            ApplyRotation(rotationStrenght);
        }
        else if (rotationInput > 0)
        {
            ApplyRotation(-rotationStrenght);
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.fixedDeltaTime);
    }
}
