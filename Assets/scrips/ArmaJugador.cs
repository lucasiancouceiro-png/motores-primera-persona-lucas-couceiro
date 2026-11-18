
using UnityEngine;
using UnityEngine.InputSystem;

public class ArmaJugador : MonoBehaviour
{
    public GameObject proyectilPrefab;
    public Transform puntoDisparo;

    public float tiempoEntreDisparos = 0.3f;

    private float proximoDisparo;

    void Update()
    {
        if (Mouse.current == null)
            return;

        if (Mouse.current.leftButton.wasPressedThisFrame &&
            Time.time >= proximoDisparo)
        {
            if (proyectilPrefab == null || puntoDisparo == null)
            {
                Debug.LogError("Falta asignar el proyectil o el punto de disparo.");
                return;
            }

            Disparar();
            proximoDisparo = Time.time + tiempoEntreDisparos;
        }
    }

    void Disparar()
    {
        Instantiate(
            proyectilPrefab,
            puntoDisparo.position,
            puntoDisparo.rotation
        );
    }
}
