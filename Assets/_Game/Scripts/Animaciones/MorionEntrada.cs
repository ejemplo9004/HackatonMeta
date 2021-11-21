using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorionEntrada : MonoBehaviour
{
    public CurvaAnimacion   curvaEntrada;
    public CurvaAnimacion   curvaSalida;
    public bool             autoIniciar = false;
    public float            tiempo = 1;
    Vector3 escalaInicial;
    void Start()
    {
        escalaInicial = transform.localScale;
        transform.localScale = escalaInicial * curvaEntrada.GetPunto(0);
        if (autoIniciar)
		{
            Entrar();
		}
    }

    public void Entrar()
	{
        StartCoroutine(Entrando());
	}


    IEnumerator Entrando()
	{
        float pasos = 1f / 15f;
		for (int i = 0; i <= 15; i++)
		{
            transform.localScale = escalaInicial * curvaEntrada.GetPunto(pasos * i);
            yield return new WaitForSeconds(tiempo * pasos);
		}
    }
    public void Salir()
    {
        StartCoroutine(Saliendo());
    }


    IEnumerator Saliendo()
    {
        float pasos = 1f / 30f;
        for (int i = 0; i <= 30; i++)
        {
            transform.localScale = escalaInicial * curvaSalida.GetPunto(pasos * i);
            yield return new WaitForSeconds(tiempo * pasos);
        }
    }
}
