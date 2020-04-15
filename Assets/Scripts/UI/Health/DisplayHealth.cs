using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHealth : MonoBehaviour, IPresenter<int>
{
    [SerializeField] private Text _display;
    [SerializeField] private string _pattern = "Health: {0}";

    public void Present(int value)
    {
        _display.text = string.Format(_pattern, value);
    }
}
