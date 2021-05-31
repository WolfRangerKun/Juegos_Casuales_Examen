using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispensadorAgua : MonoBehaviour
{
    public GameObject agua, spawnAgua;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //StartCoroutine(DispensarAgua());
            Awa();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //StopCoroutine(DispensarAgua());
        }
    }

    IEnumerator DispensarAgua()
    {
        while (true)
        {
            Instantiate(agua, spawnAgua.transform.position, Quaternion.identity);
        }
    }
    private void Awa()
    {
        Instantiate(agua, spawnAgua.transform.position, Quaternion.identity);
    }
}
