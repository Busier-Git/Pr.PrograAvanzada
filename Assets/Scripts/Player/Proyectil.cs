using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Proyectil : MonoBehaviour
{
    public float velocidad = 8f;
    private bool esDelJugador;
    private Rigidbody2D rb;

    // Awake se ejecuta ANTES que Start, al momento de instanciar
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    }

    void Update() { }

    /// <summary>
    /// Inicializa dirección y origen. Llamar justo después de Instantiate().
    /// </summary>
    public void Inicializar(Vector2 direccion, bool delJugador)
    {
        esDelJugador = delJugador;
        rb.velocity = direccion.normalized * velocidad;
        gameObject.tag = delJugador ? "ProyectilJugador" : "ProyectilEnemigo";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (esDelJugador && collision.CompareTag("Enemigo"))
            Destroy(gameObject);

        if (!esDelJugador && collision.CompareTag("Jugador"))
            Destroy(gameObject);
    }
}
