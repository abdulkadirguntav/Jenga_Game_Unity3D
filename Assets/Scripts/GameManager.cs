using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Blocks")]
    public Rigidbody[] blocks;

    [Header("Stability Settings")]
    public float velocityThreshold = 0.35f;
    public float observeTime = 3f;
    public float unstableRatio = 0.4f; // %40


    [Header("UI")]
    public GameObject gameOverCanvas;

    private float unstableTime;
    private bool checking;
    private bool gameOver;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        if (gameOverCanvas)
            gameOverCanvas.SetActive(false);
    }

    void Update()
    {
        if (!checking || gameOver) return;

        int movingCount = 0;

        foreach (var rb in blocks)
        {
            if (!rb) continue;

            if (rb.linearVelocity.magnitude > velocityThreshold)
                movingCount++;
        }

        float ratio = (float)movingCount / blocks.Length;

        if (ratio > unstableRatio)
        {
            unstableTime += Time.deltaTime;

            if (unstableTime >= observeTime)
                GameOver();
        }
        else
        {
            unstableTime = 0f;
        }
    }

    public void StartStabilityCheck()
    {
        if (gameOver) return;

        checking = true;
        unstableTime = 0f;
    }

    void GameOver()
    {
        gameOver = true;
        checking = false;

        Time.timeScale = 0f;

        if (gameOverCanvas)
            gameOverCanvas.SetActive(true);

        PlayerTurnManager.Instance?.SetGameOver();

        Debug.Log("GAME OVER");
    }
}
