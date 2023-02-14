using UnityEngine;

[RequireComponent(typeof(CameraViewChanger))]
public class PlayerInputCamera : MonoBehaviour
{
    private CameraViewChanger _viewChanger;

    private void Awake()
    {
        _viewChanger = GetComponent<CameraViewChanger>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            _viewChanger.ChangeCamera();
    }
}