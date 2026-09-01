using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int points = 10;

    public int Points => points;
}
