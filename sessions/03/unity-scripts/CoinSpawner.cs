using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private Vector3 spawnPosition = new Vector3(2f, 0f, 0f);

    private void Start()
    {
        Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
    }
}
