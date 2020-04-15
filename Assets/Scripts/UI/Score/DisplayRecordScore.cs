using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayRecordScore : MonoBehaviour
{
    [SerializeField] private string _pattern = "Ваш рекорд: {0}";

    private Text _display;

    private void Start()
    {
        _display = GetComponent<Text>();
        _display.text = string.Format(_pattern, PlayerPrefs.GetInt("recordScore"));
    }
}
