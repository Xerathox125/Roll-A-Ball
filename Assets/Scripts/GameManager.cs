using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    public TMP_Text scoreText;
    public GameObject panelWin;
    public int totalPoints = 10;
    public static GameManager instance;

    private void Awake()
    {
        score = 0;
        Time.timeScale = 1;

        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateScoreText();

        //Application.targetFrameRate = 120; //opcional para "optimizar" el juego a 120 fps, aunque no es necesario, ya que Unity ajusta automáticamente el rendimiento según el dispositivo. Si se desea limitar a un número específico de fps, se puede usar esta línea.
        //QualitySettings.vSyncCount = 1; //sincronización vertical para evitar tearing. Se puede ajustar según las necesidades del juego.
    }

    // Update is called once per frame
    void Update()
    {
        WinLevel();
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

    void WinLevel()
    {
        if (score == totalPoints)
        {
            panelWin.SetActive(true);
            Time.timeScale = 0f;
        }

    }

}
