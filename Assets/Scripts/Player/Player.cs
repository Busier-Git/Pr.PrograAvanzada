using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Movimiento : MonoBehaviour
{
    [Header("Movimiento")]
    public float velocidad = 5f;
    private Rigidbody2D rb;
    private Animator animator;

    [Header("Disparo")]
    public GameObject prefabLagrima;
    public float intervalDisparo = 0.5f;
    private float timerDisparo = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Mover();
        timerDisparo += Time.deltaTime;
         Disparar();
    }
    private void Mover()
    {
        float x = 0f;
    float y = 0f;

    // Solo WASD para moverse
    if (Input.GetKey(KeyCode.W)) y =  1f;
    if (Input.GetKey(KeyCode.S)) y = -1f;
    if (Input.GetKey(KeyCode.A)) x = -1f;
    if (Input.GetKey(KeyCode.D)) x =  1f;

    rb.velocity = new Vector2(x, y) * velocidad;

    bool seEstaMoviendo = (x != 0 || y != 0);
    if (animator != null)
        animator.SetBool("moviéndose", seEstaMoviendo);
    }

    private void Disparar()
    {
        if (timerDisparo < intervalDisparo) return;

        Vector2 dirección = Vector2.zero;
        if (Input.GetKey(KeyCode.UpArrow))    dirección = Vector2.up;
        if (Input.GetKey(KeyCode.DownArrow))  dirección = Vector2.down;
        if (Input.GetKey(KeyCode.LeftArrow))  dirección = Vector2.left;
        if (Input.GetKey(KeyCode.RightArrow)) dirección = Vector2.right;

        if (dirección != Vector2.zero)
        {
            Instantiate(prefabLagrima, transform.position, Quaternion.identity)
                .GetComponent<Proyectil>().Inicializar(dirección, true);
            timerDisparo = 0f;
        }
    }
}
