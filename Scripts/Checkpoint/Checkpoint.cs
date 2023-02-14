using UnityEngine;
using UnityEngine.Events;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private UnityEvent _reached;

    public SpawnPoint SpawnPoint { get; private set; }

    private void Awake()
    {
        SpawnPoint = GetComponentInChildren<SpawnPoint>();
    }


    public event UnityAction Reached
    {
        add => _reached.AddListener(value);
        remove => _reached.RemoveListener(value);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerCar car) == true)
        {
            _reached?.Invoke();
        }
    }
}
