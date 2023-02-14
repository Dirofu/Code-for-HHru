using UnityEngine;

[RequireComponent(typeof(MoneyProtector))]
public class GameSetter : MonoBehaviour
{
    [SerializeField] private GameObject _finishUI;
    [SerializeField] private GameObject _failUI;
    [SerializeField] private int _winReward;

    private PlayerCarChooser _carChooser;
    private RaceTimer _timer;
    private TimeStopper _timeStopper;
    private MoneyProtector _protector;
    private CarAIStarter _starterAI;

    public bool IsTimerGame { get; private set; }
    public int WinReward => _winReward;

    private void Awake()
    {
        _protector = GetComponent<MoneyProtector>();
        _carChooser = FindObjectOfType<PlayerCarChooser>();
        _timeStopper = FindObjectOfType<TimeStopper>();
        _timer = FindObjectOfType<RaceTimer>();
        _starterAI = FindObjectOfType<CarAIStarter>();

        IsTimerGame = PlayerPrefs.GetInt(Constantes.CurrentMode) == 0;

        if (IsTimerGame == true)
            DisableEnemy();
    }

    private void DisableEnemy()
    {
        _starterAI.SetActive(false);
    }

    private void ChangeRaceStatus(bool status)
    {
        _timer.gameObject.SetActive(status);
        _carChooser.GetActiveCar().GetComponent<CarController>().enabled = status;
    }

    public void StartRace()
    {
        ChangeRaceStatus(true);
        _timeStopper.StartTimeScale();
        _starterAI.StartDriving();
    }

    public void StopRace()
    {
        ChangeRaceStatus(false);
        _timeStopper.StopTimeScale();
    }

    public void ShowFinish()
    {
        _finishUI.SetActive(true);
        _protector.AddMoney(_winReward);
        _timeStopper.SlowdownToStopTimeScale();
        _timer.StopCountdown();
    }

    public void ShowFail()
    {
        _failUI.SetActive(true);
        _timeStopper.SlowdownToStopTimeScale();
        _timer.StopCountdown();
    }
}
