using UnityEngine;
using UnityEngine.InputSystem;

public class MouseAimController : MonoBehaviour
{
    
    [SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] private float minRotation = -90f;
    [SerializeField] private float maxRotation = 90f;

    private float xRotation = 0f;
    private float yRotation = 0f;



    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // remove cursor from screen
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouseInput = CustomInputManager.Instance.GetLookInput();
        xRotation += mouseInput.y * mouseSensitivity * Time.deltaTime;
        yRotation += mouseInput.x * mouseSensitivity * Time.deltaTime;

        xRotation = Mathf.Clamp(xRotation, minRotation, maxRotation);

        gameObject.transform.localRotation = Quaternion.Euler(-xRotation, yRotation, 0f);
        
    }
}
