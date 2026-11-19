
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public float velocidad = 25f;
    public float tiempoVida = 3f;
    public int daño = 1;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = transform.forward * velocidad;

        Destroy(gameObject, tiempoVida);
    }

    void OnCollisionEnter(Collision collision)
    {
        EnemyHealth enemigo = collision.gameObject.GetComponent<EnemyHealth>();

        if (enemigo != null)
        {
            enemigo.TakeDamage(daño);
        }

        Destroy(gameObject);
    }
}
