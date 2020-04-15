using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool _pause = true;
    private void OnMouseDown()
    {
        if (_pause)
        {
            Time.timeScale = 0;
            _pause = false;
        }
        else if (!_pause)
        {
            Time.timeScale = 1;
            _pause = true;
        }
    }
}
