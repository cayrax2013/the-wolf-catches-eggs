using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    [SerializeField] private int _score = 1;

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

    private void FixedUpdate()
    {
        if (transform.position.x > 0)
            transform.Rotate(0f, 0f, 47f * 0.2f);
        else
            transform.Rotate(0f, 0f, -47f * 0.2f);
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
