using UnityEngine;

public class MoneyProtector : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text _moneyText;

    private int _currentMoney;

    private int _secureCode = 17;

    private void Start()
    {
        TryShowCurrentValue();
    }

    private void TryShowCurrentValue()
    {
        if (_moneyText != null)
            _moneyText.text = GetCurrentMoney().ToString();
    }
    private void SecureMoney()
    {
        if (_currentMoney < 0)
            _currentMoney = 0;

        _currentMoney *= _secureCode;
        PlayerPrefs.SetInt(Constantes.Money, _currentMoney);
    }

    public int GetCurrentMoney() => PlayerPrefs.GetInt(Constantes.Money) / _secureCode;

    public void AddMoney(int money)
    {
        _currentMoney = GetCurrentMoney();
        _currentMoney += money;
        SecureMoney();
        TryShowCurrentValue();
    }

    public bool TryTakeMoney(int cost)
    {
        _currentMoney = GetCurrentMoney();

        if (_currentMoney - cost < 0)
            return false;

        _currentMoney -= cost;
        SecureMoney();
        TryShowCurrentValue();
        return true;       
    }
}
