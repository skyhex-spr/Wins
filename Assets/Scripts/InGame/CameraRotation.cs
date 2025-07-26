using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRotation : MonoBehaviour
{
    public float sensitivity = 2.0f;
    public float verticalClamp = 80f;
    public float smoothTime = 0.05f;

    private InputSystem_Actions inputActions;
    private Vector2 lookInput;
    private bool isRightClickHeld = false;

    private float xRotation = 0f;
    private float yRotation = 0f;

    private float smoothX;
    private float smoothY;
    private float xVelocity;
    private float yVelocity;

    public bool DisableRotation;

    void Awake()
    {
        inputActions = new InputSystem_Actions();

        inputActions.Player.Look.performed += ctx => lookInput = ctx.ReadValue<Vector2>();
        inputActions.Player.Look.canceled += ctx => lookInput = Vector2.zero;

        inputActions.CameraLook.MouseDelta.performed += ctx => isRightClickHeld = true;
        inputActions.CameraLook.MouseDelta.canceled += ctx => isRightClickHeld = false;
    }

    void OnEnable() => inputActions.Enable();
    void OnDisable() => inputActions.Disable();

    void Start()
    {
        Vector3 euler = transform.localRotation.eulerAngles;
        xRotation = euler.x;
        yRotation = euler.y;
        smoothX = xRotation;
        smoothY = yRotation;
    }

    void Update()
    {
        if (!isRightClickHeld)
            return;

        float targetMouseX = lookInput.x * sensitivity;
        float targetMouseY = lookInput.y * sensitivity;

        yRotation += targetMouseX;
        xRotation -= targetMouseY;
        xRotation = Mathf.Clamp(xRotation, -verticalClamp, verticalClamp);

        smoothX = Mathf.SmoothDampAngle(smoothX, xRotation, ref xVelocity, smoothTime);
        smoothY = Mathf.SmoothDampAngle(smoothY, yRotation, ref yVelocity, smoothTime);

        transform.localRotation = Quaternion.Euler(smoothX, smoothY, 0f);
    }
}
