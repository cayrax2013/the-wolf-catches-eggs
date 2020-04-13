using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    public Vector3 TargetPosition;

    private Vector2 _direction;
    private bool _facingRight = true;

    private void Start()
    {
        TargetPosition = transform.position;
    }

    private void Update()
    {
        Move();

        if (_direction.x < 0 && _facingRight)
            Flip();
        else if (_direction.x > 0 && !_facingRight)
            Flip();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, TargetPosition, _speed * Time.deltaTime);
        _direction = (TargetPosition - transform.position).normalized;
    }

    private void Flip()
    {
        _facingRight = !_facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
