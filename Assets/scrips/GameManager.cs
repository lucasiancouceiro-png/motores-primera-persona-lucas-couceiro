

using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int enemiesToWin = 10;
    public int enemiesKilled = 0;

    public TMP_Text enemiesText;
    public TMP_Text victoryText;
    public TMP_Text defeatText;

    public GameObject restartButton;
    public GameObject defeatImage;

    private bool gameEnded = false;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        victoryText.gameObject.SetActive(false);
        defeatText.gameObject.SetActive(false);
        restartButton.SetActive(false);
        defeatImage.SetActive(false);

        UpdateUI();
    }

    public void AddEnemyKilled()
    {
        if (gameEnded) return;

        enemiesKilled++;

        UpdateUI();

        if (enemiesKilled >= enemiesToWin)
        {
            gameEnded = true;
            victoryText.gameObject.SetActive(true);
            victoryText.text = "¡El amor siempre gana!";
            Time.timeScale = 0f;
        }
    }

    public void PlayerDefeated()
    {
        if (gameEnded) return;

        gameEnded = true;

        defeatText.gameObject.SetActive(true);
        defeatText.text = "¡Perdiste baby!";

        defeatImage.SetActive(true);
        restartButton.SetActive(true);

        Time.timeScale = 0f;
    }

    void UpdateUI()
    {
        enemiesText.text = "Elvis eliminados: " + enemiesKilled + "/" + enemiesToWin;
    }
}
