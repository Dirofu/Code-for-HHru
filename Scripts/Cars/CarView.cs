using UnityEngine;

public class CarView : MonoBehaviour
{
    [SerializeField] private CarWheel[] _wheels;

    private void OnEnable()
    {
        foreach (var wheel in _wheels)
        {
            wheel.gameObject.SetActive(true);
        }
    }
}