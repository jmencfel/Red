using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform cameraTransform;
    [Header("Settings")]
    [SerializeField] private float MouseSensitivity = 20.0f;  
    [SerializeField] private float RotationalSpeed = 5.0f;

    private float cameraPitch = 0.0f;
    private float cameraYaw = 0.0f;
    private Vector2 mouseMovement;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void FixedUpdate()
    {
        Rotate();
    }
    void Update()
    {
        GetInput();
    }
    private void GetInput()
    {
        mouseMovement.x = Input.GetAxis("Mouse X") * MouseSensitivity;
        mouseMovement.y = Input.GetAxis("Mouse Y") * MouseSensitivity;
    }
    private void Rotate()
    {
        UpDownRotation();
        LeftRightRoration();
    }
    private void UpDownRotation()
    {
        cameraPitch -= mouseMovement.y;
        cameraPitch = Mathf.Clamp(cameraPitch, -80.0f, 80.0f);
        cameraTransform.localRotation = Quaternion.Slerp(cameraTransform.localRotation,  Quaternion.Euler(cameraPitch, 0, 0), RotationalSpeed * Time.deltaTime);
    }
    private void LeftRightRoration()
    {
        cameraYaw += mouseMovement.x;
        transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.AngleAxis(cameraYaw, Vector3.up), RotationalSpeed * Time.deltaTime);
    }
}
