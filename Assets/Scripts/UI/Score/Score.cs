using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class UnityEventInt : UnityEvent<int> { }

public class Score : MonoBehaviour
{
    [SerializeField] private UnityEventInt _onScoreChanged;
    [SerializeField] private UnityEvent _reachedEnoughAmountScore;
    [SerializeField] private int _currentScore;

    public void TakeScore(int score)    
    {
        _currentScore += score;
        _onScoreChanged?.Invoke(_currentScore);

        PlayerPrefs.SetInt("currentScore", _currentScore);

        if (_currentScore > PlayerPrefs.GetInt("recordScore"))
            PlayerPrefs.SetInt("recordScore", _currentScore);

        if (_currentScore >= 50)
            _reachedEnoughAmountScore?.Invoke();

        PlayerPrefs.Save();
    }
}
