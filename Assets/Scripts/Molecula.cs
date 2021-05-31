using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Molecula : MonoBehaviour
{

    public enum TIPO_MOLECULA
    {
        CARBONO = 0,
        OXIGENO = 1,
    }
    public TIPO_MOLECULA tipoMolecula;

    private void Start()
    {
        //tipoMolecula = (TIPO_MOLECULA)Random.Range(0, 3);
        ActualizarColor();
    }
    public void ActualizarColor()
    {
        //GetComponent<SpriteRenderer>().color = Color.yellow;

        switch (tipoMolecula)
        {
            case TIPO_MOLECULA.CARBONO:
                GetComponent<SpriteRenderer>().color = Color.green;
                break;
            case TIPO_MOLECULA.OXIGENO:
                GetComponent<SpriteRenderer>().color = Color.blue;
                break;
        }

    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            //tipoMolecula = TIPO_MOLECULA.MADERA;
            ActualizarColor();
        }
    }
}
