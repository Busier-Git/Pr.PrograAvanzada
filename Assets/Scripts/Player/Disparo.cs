using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
     public GameObject prefabProyectil;
     public float intervalDisparo = 0.5f;
     private float timerDisparo = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timerDisparo += Time.deltaTime;
        VerificarDisparo();
    }
    private void VerificarDisparo()
    {
        if (timerDisparo < intervalDisparo) return;

        Vector2 direccion = Vector2.zero;

        if (Input.GetKey(KeyCode.UpArrow))    direccion = Vector2.up;
        if (Input.GetKey(KeyCode.DownArrow))  direccion = Vector2.down;
        if (Input.GetKey(KeyCode.LeftArrow))  direccion = Vector2.left;
        if (Input.GetKey(KeyCode.RightArrow)) direccion = Vector2.right;

        if (direccion != Vector2.zero)
        {
            GameObject proy = Instantiate(prefabProyectil, transform.position, Quaternion.identity);
            proy.GetComponent<Proyectil>().Inicializar(direccion, true);
            timerDisparo = 0f;
        }
    }
}
