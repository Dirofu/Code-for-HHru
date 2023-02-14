using System.Collections;
using UnityEngine;

public class StackProtector : MonoBehaviour
{
    [SerializeField] private float _maxSecondsBeforeSpawn = 2f;
    [SerializeField] private bool _isEnemy;

    private AnyCarAI _anyCar;
    private PlayerCar _car;
    private float _currentSecondsBeforeSpawn;
    private IEnumerator _spawnCountdown;
    private CheckpointTracker _tracker;

    private int _roadLayer = 3;

    private void Awake()
    {
        if (_isEnemy == false)
            _car = GetComponentInParent<PlayerCar>();
        else
            _anyCar = GetComponentInParent<AnyCarAI>();

        _tracker = FindObjectOfType<CheckpointTracker>();
        ResetTimer();
    }

    private void ResetTimer() => _currentSecondsBeforeSpawn = _maxSecondsBeforeSpawn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == _roadLayer)
        {
            StartCoroutine(_spawnCountdown = SpawnCountdown());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == _roadLayer)
        {
            StopCoroutine(_spawnCountdown);
            ResetTimer();
        }
    }

    private IEnumerator SpawnCountdown()
    {
        while (_currentSecondsBeforeSpawn > 0)
        {
            _currentSecondsBeforeSpawn -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        if (_isEnemy == false)
            TeleportToLastCheckpoint();
        else
            _anyCar.transform.localRotation = new Quaternion(0, _anyCar.transform.rotation.y, 0, 0);

        StopCoroutine(_spawnCountdown);
    }

    public void TeleportToLastCheckpoint()
    {
        Vector3 lastCheckpointPosition = _tracker.LastCheckpoint.SpawnPoint.transform.position;
        Quaternion lastCheckpointRotation = _tracker.LastCheckpoint.SpawnPoint.transform.rotation;

        _car.transform.position = lastCheckpointPosition;
        _car.transform.localRotation = lastCheckpointRotation;
        ResetTimer();
    }
}
