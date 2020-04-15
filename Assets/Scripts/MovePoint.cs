using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePoint : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerMover;

    private void OnMouseDown()
    {
        _playerMover.TargetPosition = transform.position;
    }
}
