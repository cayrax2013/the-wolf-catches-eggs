using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class Bomb : MonoBehaviour
{
    [SerializeField] private int _damage = 10;
    [SerializeField] private float _speed = 2f;

    private Rigidbody2D _rigidbody;
    private float _elapsedTime = 0;
    private bool _increaseSpeedTheFirstTime = true;
    private bool __increaseSpeedTheSecondTime = true;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerMover playerMover))
        {
            playerMover.GetComponent<Health>().TakeDamage(_damage);
            Die();
        }

        else if (collision.TryGetComponent(out Destroyer destroyer))
        {
            Die();
        }
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= 1.2f)
        {
            _elapsedTime = 0f;
            gameObject.SetActive(false);
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
