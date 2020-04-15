using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D), typeof(AudioSource))]
public class GoldEgg : MonoBehaviour
{
    [SerializeField] private int _score = 1;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private int _plusHealth;

    private Rigidbody2D _rigidbody;
    private AudioSource _audioSource;
    private bool _increaseSpeedTheFirstTime = true;
    private bool __increaseSpeedTheSecondTime = true;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerMover playerMover))
        {
            playerMover.GetComponent<Health>().TakeHealth(_plusHealth);
            _audioSource.Play();
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
