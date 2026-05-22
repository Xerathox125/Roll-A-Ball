using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    public TMP_Text scoreText;
    public int totalPoints = 10;
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoint(int point)
    {
        score += point;
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        if (scoreText != null)
            scoreText.text = score.ToString() + "/" + totalPoints.ToString();
    }

}
