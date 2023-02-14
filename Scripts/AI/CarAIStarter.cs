using UnityEngine;

public class CarAIStarter : MonoBehaviour
{
    [SerializeField] private AnyCarAI[] _cars;

    private void Awake()
    {
        _cars = GetComponentsInChildren<AnyCarAI>();
    }

    private void ChangeDrivingState(bool state)
    {
        foreach (var car in _cars)
            car.enabled = state;
    }

    public void StopDriving() => ChangeDrivingState(false);
    public void StartDriving() => ChangeDrivingState(true);
}
