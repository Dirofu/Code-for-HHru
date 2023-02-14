using UnityEngine;

public class CheckpointTracker : MonoBehaviour
{
    [SerializeField] private int _currentCheckpointId = 0;
    [SerializeField] private int _maxCountRound = 1;
    [SerializeField] private ParticleSystem _finishParticle;

    private Checkpoint[] _checkpoints;

    private int _currentCountRound = 0;

    public Checkpoint LastCheckpoint { get; private set; }
    public bool AllCheckpointsReached { get; private set; } = false;

    private void OnEnable()
    {
        _checkpoints = GetComponentsInChildren<Checkpoint>();

        foreach (var checkpoint in _checkpoints)
            checkpoint.Reached += OnCheckpointReached;
    }

    private void OnDisable()
    {
        foreach (var checkpoint in _checkpoints)
            checkpoint.Reached -= OnCheckpointReached;
    }

    private void Start()
    {
        foreach (var checkpoint in _checkpoints)
        {
            checkpoint.SetActive(false);
        }
        SetCurrentCheckpointState(true);
    }

    private void SetCurrentCheckpointState(bool state) => _checkpoints[_currentCheckpointId].gameObject.SetActive(state);

    private void OnCheckpointReached()
    {
        SetLastCheckpoint();
        SetCurrentCheckpointState(false);
        _currentCheckpointId++;

        if (_currentCheckpointId > _checkpoints.Length - 1)
        {
            _currentCheckpointId = 0;
            _currentCountRound++;

            if (_currentCountRound >= _maxCountRound)
            {
                AllCheckpointsReached = true;
                _finishParticle.Play();
            }
        }

        if (AllCheckpointsReached == false)
            SetCurrentCheckpointState(true);
    }

    private void SetLastCheckpoint() => LastCheckpoint = _checkpoints[_currentCheckpointId];
}
