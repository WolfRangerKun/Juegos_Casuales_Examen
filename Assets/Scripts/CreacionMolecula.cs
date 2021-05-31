using UnityEngine;
using System.Collections.Generic;

public class CreacionMolecula : MonoBehaviour
{
    public List<GameObject> mesa;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Inventario inventario = other.GetComponent<Inventario>();
            foreach (GameObject g in inventario.inventario)
            {
                inventario.inventario.Remove(g);
                mesa.Add(g);
                return;
            }
        }
    }
    private void Update()
    {
    }
}
