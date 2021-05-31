using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlmacenamientoAgua : MonoBehaviour
{
    public int cantidadAgua = 0;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Agua"))
        {
            if(cantidadAgua < 4)
            {
                cantidadAgua++;
                Destroy(other.gameObject);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                Inventario.intance.inventario.Add(gameObject);
            }
        }
    }
}
