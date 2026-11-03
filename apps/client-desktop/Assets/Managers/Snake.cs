using System;
using UnityEngine;
using UnityEngine.Rendering;

public class Snake : MonoBehaviour
{
    [SerializeField] private GameObject snakePrefab;
    [SerializeField] private float movingSpeed = 1f;
    private float timeSinceLastMove = 0f;
    private float timeMove = 0.5f;
    private Vector2 predVector = new Vector2(-1, 0);
    private GameObject _snake;
    private Rigidbody2D _rb;
    private Snake snake;
    void Start()
    {
        Vector3 position = new Vector3(0, 0, 0);
        _snake = Instantiate(snakePrefab, position, Quaternion.identity, gameObject.transform);
        _rb = _snake.GetComponent<Rigidbody2D>();
        Debug.Log(_rb.position);
    }

    void Update()
    {
        MoveSnake(GameInput.Instance.GetInputVector());
    }

    void MoveSnake(Vector2 newVector)
    {


        timeSinceLastMove += Time.deltaTime;

        if ((newVector != Vector2.zero) && (newVector != predVector))
        {
            predVector = newVector;
        }

        if (timeSinceLastMove > timeMove)
        {

            timeSinceLastMove -= timeMove;
            _rb.MovePosition(_rb.position + predVector * (movingSpeed * Time.fixedDeltaTime));

        }

    }


}
