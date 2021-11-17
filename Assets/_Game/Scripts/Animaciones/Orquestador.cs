using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Orquestador : MonoBehaviour
{
    public MiniOrquesta[]   orquestas;
    public string           fraseProvicional;
    public static Orquestador singleton;
	public Text txtFrase;
	public Text txtFraseEscuchada;
	public UnityEvent iniciarAudio;
	public AudioSource audioSource;

	private void Awake()
	{
		singleton = this;
	}

	int indice = 0;
    void Start()
    {
		ActualizarUI();
		Escuchar();
    }

    public void Evaluar2()
	{
		if (orquestas[indice].Evaluar(fraseProvicional))
		{
            print("correcto");
			txtFraseEscuchada.color = Color.black;
            txtFraseEscuchada.text = ("correcto");
            indice++;
			ActualizarUI();
			Escuchar();
		}
		else
		{
			txtFraseEscuchada.color = Color.red;
			txtFraseEscuchada.text = (fraseProvicional);
			Escuchar();
			Debug.LogError("Error, el texto no es el esperado, supuestamente fue:'" + fraseProvicional + "'");
		}
	}

    public void CambiarFrase(string ff)
	{
        fraseProvicional = ff;
	}

	void ActualizarUI()
	{
		if (indice < orquestas.Length)
		{
			txtFrase.text = orquestas[indice].frase;
		}
	}

	public void Escuchar()
	{
		StartCoroutine(IniciarEscucha());
	}

	public IEnumerator IniciarEscucha()
	{
		yield return new WaitForSeconds(3);
		audioSource.Play();
		yield return new WaitForSeconds(2);
		iniciarAudio.Invoke();
	}
}

[System.Serializable]
public class MiniOrquesta
{
    public string frase;
    public Orquesta orquesta;
    
    public bool Evaluar(string f)
	{
		if (frase.ToUpper().Equals(f.ToUpper()))
		{
            orquesta.Entrar();
            return true;
		}
        return false;
	}
}
