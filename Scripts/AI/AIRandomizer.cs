using UnityEngine;

public class AIRandomizer : MonoBehaviour
{
    private AnyCarAI _car;
    private float _minValueDevisor = 2f;

    private void Awake()
    {
        _car = GetComponent<AnyCarAI>();
    }

    private void Start()
    {
        _car.accelSensitivity = GetRandomValue(_car.accelSensitivity);
        _car.wanderAmount = GetRandomValue(_car.wanderAmount);
        _car.steerSensitivity = GetRandomValue(_car.steerSensitivity);
        _car.lateralWander = GetRandomValue(_car.lateralWander);
        _car.cautiousAngle = GetRandomValue(_car.cautiousAngle);
        _car.cautiousDistance = GetRandomValue(_car.cautiousDistance);
        _car.brakeSensitivity = GetRandomValue(_car.brakeSensitivity);
        _car.brakeCondition = (BrakeCondition)Random.Range(0f, 3f);
    }

    private float GetRandomValue(float value) => Random.Range((value / _minValueDevisor), value);
}
