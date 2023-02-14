using UnityEngine;

public class InputPlayerUI : MonoBehaviour
{
    [SerializeField] private GameStopper _stopper;

    public bool IsCanStopGame { get; private set; } = false;

    private void Start()
    {
        DisablePauseButton();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _stopper.PauseGame();
        }
    }

    public void EnablePauseButton() => IsCanStopGame = true;
    public void DisablePauseButton() => IsCanStopGame = false;
}