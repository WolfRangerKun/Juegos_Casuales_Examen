using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    public static Inventario intance;
    public List<GameObject> inventario;

    private void Start()
    {
        intance = this;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Molecula"))
        {
            inventario.Add(other.gameObject);
            other.gameObject.SetActive(false);
        }
    }
}
