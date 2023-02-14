using UnityEngine;

public class EventRedirector : MonoBehaviour
{
    [SerializeField] private GameSetter _setter;
    [SerializeField] private InputPlayerUI _inputUI;

    public void RedirectStartRaceEvent()
    {
        _setter.StartRace();
    }

    public void PauseButtonEnable()
    {
        _inputUI.EnablePauseButton();
    }
}
