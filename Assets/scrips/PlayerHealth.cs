

using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 7;
    public TMP_Text livesText;

    private int currentHealth;
    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateLivesUI();

        Debug.Log("Vidas del jugador: " + currentHealth);
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);

        UpdateLivesUI();

        Debug.Log("Vidas del jugador: " + currentHealth);

        if (currentHealth <= 0)
        {
            isDead = true;
            Debug.Log("DERROTA");

            if (GameManager.Instance != null)
            {
                GameManager.Instance.PlayerDefeated();
            }
        }
    }

    void UpdateLivesUI()
    {
        if (livesText != null)
        {
            livesText.text = "HP: " + currentHealth;
        }
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public bool IsDead()
    {
        return isDead;
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1);
        }
    }
}
