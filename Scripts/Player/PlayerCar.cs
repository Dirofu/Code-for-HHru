using UnityEngine;

public class PlayerCar : MonoBehaviour
{
    [SerializeField] private CarTypes _type;
    [SerializeField] private int _cost;

    public StackProtector StackProtector { get; private set; }

    public string Type => _type.ToString();
    public int Cost => _cost;

    private void OnEnable()
    {
        StackProtector = GetComponentInChildren<StackProtector>();
    }
}

enum CarTypes
{
    CarSport,
    CarDrift,
    CarSuper
}