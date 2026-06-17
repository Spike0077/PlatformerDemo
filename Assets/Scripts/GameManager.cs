using UnityEngine;
using TMPro; // 替换原来的 UnityEngine.UI

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private TextMeshProUGUI scoreText; // 替换原来的 Text
    private int _currentScore = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int value)
    {
        _currentScore += value;
        scoreText.text = $"game: 0{_currentScore}";
    }
}