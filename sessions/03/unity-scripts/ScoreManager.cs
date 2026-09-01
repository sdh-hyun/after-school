using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score;

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log($"Score: {score}");
    }
}
