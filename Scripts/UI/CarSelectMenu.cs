using Cinemachine;
using UnityEngine;

public class CarSelectMenu : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _camera;
    [SerializeField] private PlayerCarChooser _chooser;
    [SerializeField] private TMPro.TMP_Text _costText;
    [SerializeField] private MenuButtons _menuButtons;

    [Header("Buttons")]
    [SerializeField] private GameObject _selectedButton;
    [SerializeField] private GameObject _selectButton;
    [SerializeField] private GameObject _buyButton;
    
    private MoneyProtector _money;
    private Animator _buyButtonAnimator;
    private Animator _animator;
    private PlayerCar _currentCar;

    private int _currentCarId = 0;
    private int _minCarId = 0;
    private int _maxCarId => _chooser.MaxCarID;

    private void OnEnable()
    {
        _buyButtonAnimator = _buyButton.GetComponent<Animator>();
        _animator = _camera.GetComponent<Animator>();
        _money = _menuButtons.GetComponent<MoneyProtector>();
        SetAnimationBool(Constantes.IsChooseCar, true);
        _currentCarId = _chooser.GetChoosedCarID();
        UpdateButton();
    }

    private void OnDisable()
    {
        SetAnimationBool(Constantes.IsChooseCar, false);
    }

    private void UpdateButton()
    {
        DisableButtons();
        _currentCar = _chooser.GetSelectCarID(_currentCarId);

        if (PlayerPrefs.GetInt(Constantes.ChoosedCarID) == _currentCarId)
        {
            _selectedButton.SetActive(true);
        }
        else if (PlayerPrefs.GetInt(_currentCar.Type) == Constantes.AvailableValue)
        {
            _selectButton.SetActive(true);
        }
        else if (PlayerPrefs.GetInt(_currentCar.Type) == Constantes.BuyValue)
        {
            _buyButton.SetActive(true);
            _costText.text = _currentCar.Cost.ToString();
        }
    }

    private void DisableButtons()
    {
        _selectedButton.SetActive(false);
        _selectButton.SetActive(false);
        _buyButton.SetActive(false);
    }

    private void SetAnimationBool(string name, bool value) => _animator.SetBool(name, value);
    
    private void ChooseCar(int offset)
    {
        _chooser.DeactivateCarId(_currentCarId);
        _currentCarId = GetCorrectID(_currentCarId + offset);
        _chooser.ActivateCarId(_currentCarId);
    }

    private int GetCorrectID(int value)
    {
        if (value > _maxCarId)
            return _minCarId;
        else if (value < _minCarId)
            return _maxCarId;

        return value;
    }

    public void PreviousCarButton()
    {
        ChooseCar(-1);
        UpdateButton();
    }
    public void NextCarButton()
    {
        ChooseCar(1);
        UpdateButton();
    }
    public void SelectCarButton()
    {
        PlayerPrefs.SetInt(Constantes.ChoosedCarID, _currentCarId);
        UpdateButton();
    }

    public void TryBuyButton()
    {
        if (_money.TryTakeMoney(_currentCar.Cost) == true)
        {
            SelectCarButton();
            PlayerPrefs.SetInt(_currentCar.Type, Constantes.AvailableValue);
        }
        else
        {
            _buyButtonAnimator.SetTrigger(Constantes.CantBuyTrigger);
        }
    }

    public void ExitButton()
    {
        _chooser.DeactivateCarId(_currentCarId);
        _chooser.ActivateCarId(_chooser.GetChoosedCarID());
        _menuButtons.CloseStoreMenuButton();
    }
}
