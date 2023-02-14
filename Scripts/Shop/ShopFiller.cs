using UnityEngine;

public class ShopFiller : MonoBehaviour
{
    private void Start()
    {
        if (PlayerPrefs.GetInt(Constantes.FirstInitialization) == Constantes.BuyValue)
        {
            FirstInitFill();
            PlayerPrefs.SetInt(Constantes.FirstInitialization, Constantes.AvailableValue);
        }    
    }

    private void FirstInitFill()
    {
        PlayerPrefs.SetInt(Constantes.CarSport, Constantes.AvailableValue);
        PlayerPrefs.SetInt(Constantes.CarDrift, Constantes.BuyValue);
        PlayerPrefs.SetInt(Constantes.CarSuper, Constantes.BuyValue);
    }
}