using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _stepSize = 3f;
    [SerializeField] private float _minXPos = -3f;
    [SerializeField] private float _maxXPos = 3f;

    private Rigidbody2D _rigidbody2D;
    private Vector3 _targetPosition;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        _targetPosition = transform.position;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
    }

    public void MoveRight()
    {
        if (_targetPosition.x < _maxXPos)
            SetNextPosition(_stepSize);
    }

    public void MoveLeft()
    {
        if (_targetPosition.x > _minXPos)
            SetNextPosition(-_stepSize);
    }

    private void SetNextPosition(float stepSize)
    {
        _targetPosition = new Vector2(_targetPosition.x + stepSize, _targetPosition.y);
    }
}
