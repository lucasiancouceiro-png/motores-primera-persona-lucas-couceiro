
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;

    private int currentHealth;
    private bool isDead = false;
    private EnemyAI enemyAI;
    private Animator animator;

    void Start()
    {
        currentHealth = maxHealth;
        enemyAI = GetComponent<EnemyAI>();
        animator = GetComponentInChildren<Animator>();
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
        else
        {
            if (enemyAI != null)
            {
                enemyAI.TakeDamageAnimation();
            }
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

        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddEnemyKilled();
        }

        if (enemyAI != null)
        {
            enemyAI.DieAnimation();
            enemyAI.enabled = false;
        }

        Destroy(gameObject, 3f);
    }

}
