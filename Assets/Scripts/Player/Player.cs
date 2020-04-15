using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private UnityEvent _cameAcrossBomb;
    [SerializeField] private UnityEvent _cameAcrossGoldEgg;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Bomb bomb))
            _cameAcrossBomb?.Invoke();

        if (collision.TryGetComponent(out GoldEgg goldEgg))
            _cameAcrossGoldEgg?.Invoke();
    }
}
