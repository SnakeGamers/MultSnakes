using System;
using UnityEngine;
using UnityEngine.Rendering;
using System.Collections.Generic;

public class Snake : MonoBehaviour
{
    [SerializeField] private GameObject headSnakePrefab;
    [SerializeField] private GameObject bodySnakePrefab;
    [SerializeField] private float movingSpeed = 1f;
    private float timeSinceLastMove = 0f;
    private float timeMove = 0.1f;
    private Vector2 predVector = new Vector2(-1, 0);
    private GameObject _headSnake;
    private GameObject _bodySnake;
    private Rigidbody2D _rbHead;
    private Rigidbody2D _rbBody;

    private List<GameObject> bodySnakeTiles = new List<GameObject>();

    void Start()
    {
        Transform transformParent = gameObject.transform.parent;
        Default def = transformParent.GetComponent<Default>();

        Vector3 positionHead = def.vectors[0];
        Vector3 positionBody1 = def.vectors[1];
        Vector3 positionBody2 = def.vectors[2];//Если надо изменить z придется писать через new Vector3
        //Создание головы
        _headSnake = Instantiate(headSnakePrefab, positionHead, Quaternion.identity, gameObject.transform);
        _rbHead = _headSnake.GetComponent<Rigidbody2D>();

        //Создание тела
        bodySnakeTiles.Add(Instantiate(bodySnakePrefab, positionBody1, Quaternion.identity, gameObject.transform));
        bodySnakeTiles.Add(Instantiate(bodySnakePrefab, positionBody2, Quaternion.identity, gameObject.transform));
    }

    void Update()
    {
        MoveSnake(GameInput.Instance.GetInputVector());
    }

    private void MoveSnake(Vector2 newVector)
    {
        timeSinceLastMove += Time.deltaTime;

        if (
                (newVector != Vector2.zero) &&
                isBlockedVector(newVector) &&
                isBackVector(newVector, predVector) &&
                (newVector != predVector)
            )
        {
            predVector = newVector;
        }

        if (timeSinceLastMove > timeMove)
        {

            timeSinceLastMove -= timeMove;
            Vector2 current = _rbHead.position;
            _rbHead.MovePosition(_rbHead.position + predVector * (movingSpeed * Time.fixedDeltaTime));

            //_rbBody.MovePosition(current);
            MoveBodyTile(current);
        }
    }

    private bool isBlockedVector(Vector2 newVector)
    {
        if (Math.Abs(newVector.x) <= 0.01f || Math.Abs(newVector.y) <= 0.01f)
        {
            return true;
        }
        return false;
    }

    private bool isBackVector(Vector2 newVector, Vector2 current)
    {
        if (-newVector.x == current.x || -newVector.y == current.y)
        {
            return false;
        }
        return true;
    }
    private void MoveBodyTile(Vector2 positionHead)
    {
        Vector2 positionPredBody = positionHead;
        Rigidbody2D rbBody; 

        foreach (GameObject tile in bodySnakeTiles) {

            rbBody = tile.GetComponent<Rigidbody2D>();
            rbBody.MovePosition(positionPredBody);
            positionPredBody = rbBody.position;
        }
    }
}
