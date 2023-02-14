using UnityEngine;

public class LookAtPoint : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;

    private PlayerCar _car;

    private void Update()
    {
        if (_car != null)
            transform.position = _car.transform.position + _offset;
        else
            Debug.LogError("Look at car point Undefind");
    }

    public void SetCar(PlayerCar car) => _car = car;
}
