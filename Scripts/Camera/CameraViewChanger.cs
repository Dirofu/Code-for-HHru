using UnityEngine;

[RequireComponent(typeof(CameraSetter))]
public class CameraViewChanger : MonoBehaviour
{
    [SerializeField] private GameObject[] _cameras;

    private CameraSetter _setter;
    private int _currentCameraID;

    private void Awake()
    {
        _setter = GetComponent<CameraSetter>();
        _currentCameraID = PlayerPrefs.GetInt(Constantes.CurrentCameraID);
        SetCameraView();
    }

    private void DeactivateCameraOnID(int id) => _cameras[id].SetActive(false);
    private void ActivateCameraOnID(int id) => _cameras[id].SetActive(true);

    private int GetNextApplyID(int offset)
    {
        _currentCameraID += offset;

        if (_currentCameraID > _cameras.Length - 1)
            _currentCameraID = 0;

        return _currentCameraID;
    }

    private void SendCameraSettings()
    {
        _setter.SetVirtualCamera(GetCurrentCamera());
        _setter.SetCameraSettings();
    }

    private void SetCameraView()
    {
        ActivateCameraOnID(_currentCameraID);
        SendCameraSettings();
        PlayerPrefs.SetInt(Constantes.CurrentCameraID, _currentCameraID);
    }

    public GameObject GetCurrentCamera() => _cameras[_currentCameraID];

    public void ChangeCamera()
    {
        DeactivateCameraOnID(_currentCameraID);

        _currentCameraID = GetNextApplyID(1);
        SetCameraView();
    }
}