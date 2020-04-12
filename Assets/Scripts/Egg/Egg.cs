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
        }

        Die();
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
