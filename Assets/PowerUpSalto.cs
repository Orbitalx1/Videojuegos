using System.Collections;
using UnityEngine;

public class PowerUpSalto : MonoBehaviour
{
    public float jumpBoost = 5f;  
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
            movimiento.jumpForce += jumpBoost; 
            GetComponent<MeshRenderer>().enabled = false; 
            GetComponent<Collider>().enabled = false;

            yield return new WaitForSeconds(duration); 

            movimiento.jumpForce -= jumpBoost; 
            Destroy(gameObject); 
        }
    }
}


