using System;
using TMPro;
using UnityEngine;

public class RaceTimer : MonoBehaviour
{
    [SerializeField] private GameSetter _gameSetter;
    [SerializeField] private float _maxTime;    
    [SerializeField] private TMP_Text _timer;

    private Animator _animator;

    private float _currentTime;

    private float _oneMinuteValue = 60f;
    private float _secondIsLowTimeout = 10f;
    private float _millisecondOffset = 1000f;

    private bool _isCountdownOn = true;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _currentTime = _maxTime;
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (_isCountdownOn == true)
        {
            CalculateTime();
        }
    }

    private void CalculateTime()
    {
        int minutes = (int)(_currentTime / _oneMinuteValue);

        if (minutes > 0)
        {
            float seconds = _currentTime - (_oneMinuteValue * minutes);
            string secondsText = (int)seconds < 10 ? $"0{(int)seconds}" : ((int)seconds).ToString();
            string milliseconds = ((int)(Math.Round(_currentTime - (int)_currentTime, 3) * _millisecondOffset)).ToString();
            ShowTime($"{minutes}:{secondsText}:{milliseconds}");
        }
        else
        {
            ApplyTimeLimits();
            ShowTime(Math.Round(_currentTime, 3).ToString());
        }

        _currentTime -= Time.deltaTime;
    }

    private void ApplyTimeLimits()
    {
        if (CheckUnderTimerDown(0) == true)
        {
            _currentTime = 0;
            _isCountdownOn = false;
            _gameSetter.ShowFail();
        }
        else if (CheckUnderTimerDown(_secondIsLowTimeout) == true &&
            _animator.GetBool("isLowTimeOut") == false)
        {
            _animator.SetBool("isLowTimeOut", true);
        }
    }

    private bool CheckUnderTimerDown(float value) => _currentTime <= value;
    private void ShowTime(string text) => _timer.text = text;

    public void StartCountdown() => _isCountdownOn = true;
    public void StopCountdown() => _isCountdownOn = false;
}
