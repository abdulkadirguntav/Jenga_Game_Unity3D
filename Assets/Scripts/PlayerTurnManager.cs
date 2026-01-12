using UnityEngine;
using TMPro;

public class PlayerTurnManager : MonoBehaviour
{
    public static PlayerTurnManager Instance;

    public TextMeshProUGUI turnText;

    private int currentPlayer = 1;
    private bool gameOver = false;

    void Awake()
    {
        Instance = this;
        UpdateText();
    }

    public void NextTurn()
    {
        if (gameOver) return;

        currentPlayer = (currentPlayer == 1) ? 2 : 1;
        UpdateText();
    }

    public void SetGameOver()
    {
        gameOver = true;
    }

    void UpdateText()
    {
        turnText.text = $"Oyuncu {currentPlayer}'in Sırası";
    }
}
