using UnityEngine;

public class GameStopper : MonoBehaviour
{
    [SerializeField] private GameSetter _gameSetter;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private InputPlayerUI _inputUI;
    public void PauseGame()
    {
        if (_inputUI.IsCanStopGame == true)
        {
            _pauseMenu.SetActive(true);
            _gameSetter.StopRace();
        }
    }

    public void ContinueGame()
    {
        _pauseMenu.SetActive(false);
        _gameSetter.StartRace();
    }
}