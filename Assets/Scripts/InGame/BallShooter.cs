using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallShooter : IntractionObjectController
{
    public float forceAmount = 10f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMouseDown()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        rb.AddForce(Vector3.up * forceAmount, ForceMode.Impulse);
    }
}
