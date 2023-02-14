using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(CameraViewChanger))]
public class CameraSetter : MonoBehaviour
{
    [SerializeField] private PlayerCarChooser _chooser;
    [SerializeField] private LookAtPoint _lookAt;

    private CinemachineVirtualCamera _camera;
    private PlayerCar _car;

    private void Start()
    { 
        _car = _chooser.GetActiveCar();
        _lookAt.SetCar(_car);
        SetCameraSettings();
    }

    public void SetVirtualCamera(GameObject camera) => _camera = camera.GetComponent<CinemachineVirtualCamera>();

    public void SetCameraSettings()
    {
        _camera.Follow = _car.transform;
        _camera.LookAt = _lookAt.transform;
    }
}
