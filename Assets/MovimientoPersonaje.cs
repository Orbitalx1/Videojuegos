using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovimientoPersonaje : MonoBehaviour
{
    public float velocidad = 5f;
    public float Fuerzasalto = 5f;
    private Rigidbody rb;
    private bool esSuelo;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * velocidad;
        float moveZ = Input.GetAxis("Vertical") * velocidad;

        Vector3 movement = new Vector3(moveX, 0f, moveZ);
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);

        if (Input.GetButtonDown("Jump") && esSuelo)
        {
            rb.AddForce(Vector3.up * Fuerzasalto, ForceMode.Impulse);
            esSuelo = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            esSuelo = true;
        }
    }
}
