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
        if (rotation.IsPressed()) { }
    }
}
