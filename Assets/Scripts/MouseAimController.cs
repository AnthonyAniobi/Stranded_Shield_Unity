using UnityEngine;
using UnityEngine.InputSystem;

public class MouseAimController : MonoBehaviour
{
    
    [SerializeField] private float mouseSensitivity = 100f;

    private float xRotation = 0f;
    private float yRotation = 0f;

    private Rigidbody rb;
    private bool hasRigidbody = false;

    void Start()
    {

        hasRigidbody = TryGetComponent<Rigidbody>(out rb);
        Cursor.lockState = CursorLockMode.Locked; // remove cursor from screen
    }

    // Update is called once per frame
    void Update()
    {
        InputAction mouseInput = InputSystem.actions.FindAction("Look");
        xRotation += mouseInput.ReadValue<Vector2>().y * mouseSensitivity * Time.deltaTime;
        yRotation += mouseInput.ReadValue<Vector2>().x * mouseSensitivity * Time.deltaTime;

        if (hasRigidbody)
        {
            rb.gameObject.transform.localRotation = Quaternion.Euler(-xRotation, yRotation, 0f);
        }
    }
}
