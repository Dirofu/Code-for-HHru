using System.Collections.Generic;
using UnityEngine;

public class PlayerCarChooser : MonoBehaviour
{
    [SerializeField] private List<PlayerCar> _playerCars;

    public int MaxCarID => _playerCars.Count - 1;

    private void Start()
    {
        _playerCars[GetChoosedCarID()].gameObject.SetActive(true);
    }

    public int GetChoosedCarID() => PlayerPrefs.GetInt(Constantes.ChoosedCarID);
    public PlayerCar GetActiveCar() => _playerCars[GetChoosedCarID()];
    public PlayerCar GetSelectCarID(int id) => _playerCars[id];
    public void ActivateCarId(int id) => _playerCars[id].gameObject.SetActive(true);
    public void DeactivateCarId(int id) => _playerCars[id].gameObject.SetActive(false);
}
