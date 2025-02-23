using System.Collections;
using UnityEngine;

public class PowerUpVelocidad : MonoBehaviour
{
    public float speedBoost = 5f;  
    public float duration = 5f;   

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            StartCoroutine(AplicarEfecto(other.gameObject));
        }
    }

    private IEnumerator AplicarEfecto(GameObject jugador)
    {
        MovimientoPersonaje movimiento = jugador.GetComponent<MovimientoPersonaje>();

        if (movimiento != null)
        {
            movimiento.speed += speedBoost; 
            GetComponent<MeshRenderer>().enabled = false; 
            GetComponent<Collider>().enabled = false;

            yield return new WaitForSeconds(duration); 

            movimiento.speed -= speedBoost; 
            Destroy(gameObject); 
        }
    }
}
