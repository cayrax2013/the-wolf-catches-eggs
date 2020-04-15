using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Egg : MonoBehaviour
{
    [SerializeField] private int _score = 1;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _maxSpeed = 3f;

    private Rigidbody2D _rigidbody;
    private bool _increaseSpeedTheFirstTime = true;
    private bool __increaseSpeedTheSecondTime = true;

    public void IncreasedSpeed()
    {
        _speed += 0.5f;
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerMover playerMover))
        {
            playerMover.GetComponent<Score>().TakeScore(_score);
            Die();
        }

        else if (collision.TryGetComponent(out Destroyer destroyer))
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Bomb bomb))
        {
            bomb.gameObject.SetActive(false);
            Die();
        }
    }

    private void FixedUpdate()
    {
        if (transform.position.x > 0)
        {
            transform.Rotate(0f, 0f, 47f * 0.2f);
            _rigidbody.velocity = new Vector2(-1 * _speed, _rigidbody.velocity.y);
        }
        else
        {
            transform.Rotate(0f, 0f, -47f * 0.2f);
            _rigidbody.velocity = new Vector2(1 * _speed, _rigidbody.velocity.y);
        }

        if (PlayerPrefs.GetInt("currentScore") == 100 && __increaseSpeedTheSecondTime)
        {
            __increaseSpeedTheSecondTime = false;
            _speed++;
        }

        if (PlayerPrefs.GetInt("currentScore") == 50 && _increaseSpeedTheFirstTime)
        {
            _increaseSpeedTheFirstTime = false;
            _speed++;
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
