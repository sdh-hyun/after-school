using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;

    private void Awake()
    {
        Debug.Log("PlayerCollector 준비");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Coin coin = other.GetComponent<Coin>();
        if (coin == null) return;

        scoreManager.AddScore(coin.Points);
        Destroy(other.gameObject);
    }
}
