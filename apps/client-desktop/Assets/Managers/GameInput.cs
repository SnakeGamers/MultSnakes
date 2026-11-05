using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }
    private SnakeInputActions _snakeInputActions;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instance = this;
        _snakeInputActions = new SnakeInputActions();
        _snakeInputActions.Enable();

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public Vector2 GetInputVector()
    {
        return _snakeInputActions.Snake.Move.ReadValue<Vector2>();
    }

}
