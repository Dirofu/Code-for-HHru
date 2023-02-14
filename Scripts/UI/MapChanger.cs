using UnityEngine;

public class MapChanger : MonoBehaviour
{
    [SerializeField] private Map[] _maps;

    private int _currentMap = 0;
    private int _minMapID = 0;
    private int _maxMapID => _maps.Length - 1;

    private void SetCurrentMapStatus(bool value) => _maps[_currentMap].SetActive(value);

    private void ChooseMap(int offset)
    {
        SetCurrentMapStatus(false);
        _currentMap = GetCorrectID(_currentMap + offset);
        SetCurrentMapStatus(true);
    }

    private int GetCorrectID(int value)
    {
        if (value > _maxMapID)
            return _minMapID;
        else if (value < _minMapID)
            return _maxMapID;

        return value;
    }

    public void NextMap() => ChooseMap(1);
    public void PreviousMap() => ChooseMap(-1);

}
