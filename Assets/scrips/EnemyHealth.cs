
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3;

    private int currentHealth;
    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;

        currentHealth = Mathf.Max(currentHealth, 0);

        Debug.Log("Vida del enemigo: " + currentHealth + "/" + maxHealth);

        if (currentHealth <= 0)
        {
            Die();
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

    void Die()
    {
        isDead = true;

        Debug.Log("Enemigo eliminado");

        Destroy(gameObject);
    }
}
