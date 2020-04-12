using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour, IPresenter<int>
{
    [SerializeField] private Text _display;
    [SerializeField] private string _pattern = "Score: {0}";
    public void Present(int value)
    {
        _display.text = string.Format(_pattern, value);
    }
}
