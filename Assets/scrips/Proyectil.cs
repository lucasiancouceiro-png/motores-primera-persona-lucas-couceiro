
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public float velocidad = 25f;
    public float tiempoVida = 3f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = transform.forward * velocidad;

        Destroy(gameObject, tiempoVida);
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
