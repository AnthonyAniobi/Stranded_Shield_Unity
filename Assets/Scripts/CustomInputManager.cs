using UnityEngine;
using UnityEngine.InputSystem;

public class CustomInputManager : MonoBehaviour
{
    
    public static CustomInputManager Instance { get; private set; }

    private InputActionMap inputMap;

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void Start()
    {
        inputMap = InputSystem.actions.FindActionMap("Player");
        inputMap.Enable();
    }

    Vector2 GetMoveInput()
    {
        InputAction moveInput = inputMap.FindAction("Move");
        return moveInput.ReadValue<Vector2>();
    }

    bool IsJumpPressed()
    {
        InputAction jumpInput = inputMap.FindAction("Jump");
        return jumpInput.triggered;
    }

    Vector2 GetLookInput()
    {
        InputAction lookInput = inputMap.FindAction("Look");
        return lookInput.ReadValue<Vector2>();
    }

    
}
