using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class MoneyIncreaser : MonoBehaviour
{
    [SerializeField] private GameSetter _setter;

    private ParticleSystem _particle;
    private TMP_Text _moneyUI;

    private float _currentMoney;
    private int _speedIncrease = 30;
    private float _stepIncrease = 20;

    private void Awake()
    {
        _moneyUI = GetComponent<TMP_Text>();
        _particle = GetComponentInChildren<ParticleSystem>();
    }

    private void OnEnable()
    {
        _particle.gameObject.SetActive(false);
        _currentMoney = 0;
        StartCoroutine(IncreaseMoney());
    }

    private void ShowMoneyValue() => _moneyUI.text = ((int)_currentMoney).ToString();

    private IEnumerator IncreaseMoney()
    {
        while(_currentMoney != _setter.WinReward)
        {
            _currentMoney += _speedIncrease * _stepIncrease * Time.deltaTime;

            if (_currentMoney > _setter.WinReward)
                _currentMoney = _setter.WinReward;

            ShowMoneyValue();
            yield return new WaitForEndOfFrame();
        }
        _particle.gameObject.SetActive(true);
        StopCoroutine(IncreaseMoney());
    }
}
