using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orquestador : MonoBehaviour
{
    public MiniOrquesta[]   orquestas;
    public string           fraseProvicional;

    int indice = 0;
    void Start()
    {
        
    }

    public void Evaluar()
	{
		if (orquestas[indice].Evaluar(fraseProvicional))
		{
            print("correcto");
		}
		else
		{
            Debug.LogError("Error, el texto no es el esperado");
		}
	}

    public void CambiarFrase(string ff)
	{
        fraseProvicional = ff;
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
