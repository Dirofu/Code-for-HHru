using UnityEngine;

public class PlayMenu : MonoBehaviour
{
    [SerializeField] private GameObject _modePanel;
    [SerializeField] private GameObject _mapPanel;

    private int _currentMode = 0;
    private int _currentMap = 0;

    private void OnEnable()
    {
        SetActiveState(_modePanel, true);
        SetActiveState(_mapPanel, false);
    }

    private void OnDisable()
    {
        SetActiveState(_modePanel, false);
        SetActiveState(_mapPanel, true);
    }

    private void SetActiveState(GameObject target, bool state) => target.SetActive(state);

    public void SetTimerModeButton()
    {
        SetActiveState(_modePanel, false);
        SetActiveState(_mapPanel, true);

        _currentMode = 0;
        PlayerPrefs.SetInt(Constantes.CurrentMode, _currentMode);
    }

    public void SetRaceModeButton()
    {
        SetActiveState(_modePanel, false);
        SetActiveState(_mapPanel, true);

        _currentMode = 1;
        PlayerPrefs.SetInt(Constantes.CurrentMode, _currentMode);
    }

    private void SetCurrentMap(int offset)
    {
        _currentMap += offset;
    }
    public void ChangeMapLeft() => SetCurrentMap(-1);
}