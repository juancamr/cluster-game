using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStickToTruck : MonoBehaviour
{
    private Transform originalParent; // Guardar el padre original del jugador

    private void Start()
    {
        // Guardamos el padre inicial del jugador
        originalParent = transform.parent;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Verificamos si el jugador colisiona con un camión
        if (collision.gameObject.CompareTag("Truck"))
        {
            // Hacer que el jugador sea hijo del camión
            transform.SetParent(collision.transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Cuando el jugador salga del camión, restaurar el padre original
        if (collision.gameObject.CompareTag("Truck"))
        {
            transform.SetParent(originalParent);
        }
    }
}
