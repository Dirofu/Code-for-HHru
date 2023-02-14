using UnityEngine;

public class OutOfBounceRespawner : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerCar car))
            car.StackProtector.TeleportToLastCheckpoint();
    }
}
