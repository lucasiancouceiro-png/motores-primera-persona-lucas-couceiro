

using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public EnemyHealth enemyHealth;
    public Image healthFill;

    void Update()
    {
        if (enemyHealth != null && healthFill != null)
        {
            float vida = (float)enemyHealth.GetCurrentHealth() / enemyHealth.maxHealth;

            healthFill.fillAmount = vida;

            healthFill.color = Color.Lerp(Color.red, Color.green, vida);
        }
    }
}
