using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class DisplayScoreForOneGame : MonoBehaviour
{
    [SerializeField] private string _pattern = "Вы собрали: {0} яиц";

    private Text _display;

    private void Start()
    {
        _display = GetComponent<Text>();
        _display.text = string.Format(_pattern, PlayerPrefs.GetInt("currentScore"));
    }
}
