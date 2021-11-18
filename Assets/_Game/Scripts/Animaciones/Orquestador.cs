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
		Escuchar(5);
    }

    public void Evaluar2()
	{
		if (orquestas[indice].Evaluar(fraseProvicional))
		{
            //print("correcto");
			txtFraseEscuchada.color = Color.black;
            txtFraseEscuchada.text = ("correcto");
            indice++;
			ActualizarUI();
			Escuchar(10);
		}
		else
		{
			txtFraseEscuchada.color = Color.red;
			txtFraseEscuchada.text = (fraseProvicional);
			//Debug.LogError("Error, el texto no es el esperado, supuestamente fue:'" + fraseProvicional + "'");
			Escuchar();
		}
	}

	public void ErrorEscuchando()
	{
		txtFraseEscuchada.color = Color.red;
		txtFraseEscuchada.text = ("Error trying to listen, try again");
		Escuchar();
	}

	public void ImprimirAlerta(string mensa)
	{
		//Debug.LogWarning(mensa);
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
		StartCoroutine(IniciarEscucha(0.5f));
	}
	public void Escuchar(int cuanto)
	{
		StartCoroutine(IniciarEscucha(cuanto));
	}

	public IEnumerator IniciarEscucha(float cuanto)
	{
		yield return new WaitForSeconds(cuanto);
		audioSource.Play();
		yield return new WaitForSeconds(0.5f);
		iniciarAudio.Invoke();
	}
}

[System.Serializable]
public class MiniOrquesta
{
    public string frase;
	public string[] frasesAlternativas;
    public Orquesta orquesta;
    
    public bool Evaluar(string f)
	{
		if (frase.ToUpper().Equals(f.ToUpper()))
		{
            orquesta.Entrar();
            return true;
		}
		else
		{
			for (int i = 0; i < frasesAlternativas.Length; i++)
			{
				if (frasesAlternativas[i].ToUpper().Equals(f.ToUpper()))
				{
					orquesta.Entrar();
					return true;
				}
			}
		}
        return false;
	}
}
