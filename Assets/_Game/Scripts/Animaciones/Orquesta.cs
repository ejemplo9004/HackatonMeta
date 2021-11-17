using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Orquesta : MonoBehaviour
{
    public bool             autoIniciar;
    public Instrumento[]    instrumentos;

	private void Start()
	{
		if (autoIniciar)
		{
            StartCoroutine(Entrando());
		}
	}

    [ContextMenu("Entrar")]
    public void Entrar()
	{
        StartCoroutine(Entrando());
    }

    IEnumerator Entrando()
	{
		for (int i = 0; i < instrumentos.Length; i++)
		{
            yield return new WaitForSeconds(instrumentos[i].delay0);
            instrumentos[i].Entrar();
            yield return new WaitForSeconds(instrumentos[i].delay1);
            instrumentos[i].evento.Invoke();
		}
    }

    [ContextMenu("Salir")]
    public void Salir()
    {
        StartCoroutine(Saliendo());
    }

    IEnumerator Saliendo()
    {
        for (int i = instrumentos.Length -1; i >=0 ; i--)
        {
            yield return new WaitForSeconds(instrumentos[i].delay1);
            instrumentos[i].Salir();
        }
    }
}
[System.Serializable]
public class Instrumento
{
    public float delay0;
    public MorionEntrada curva;
    public float delay1;
    public UnityEvent evento;

    public void Entrar()
    {
        if(curva != null)
            curva.Entrar();
    }
    public void Salir()
    {
        if(curva != null)
            curva.Salir();
    }



}
