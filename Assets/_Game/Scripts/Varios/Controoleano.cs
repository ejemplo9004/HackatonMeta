using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controoleano : MonoBehaviour
{
    public static Controoleano singleton;

    public MisBooles[] booles;

    void Awake()
    {
        singleton = this;
    }

    public bool Buscar(string e)
	{
		for (int i = 0; i < booles.Length; i++)
		{
			if (booles[i].etiqueta == e)
			{
                return (booles[i].estado);
			}
		}
        return false;
	}

    public void ActivaDesactiva(string e, bool que)
	{
		for (int i = 0; i < booles.Length; i++)
		{
			if (booles[i].etiqueta == (e))
			{
				booles[i].estado = que;
			}
		}
	}

	public void Activar(string e)
	{
		ActivaDesactiva(e, true);
		print("activado + " + e);
	}
	public void Desactivar(string e)
	{
		ActivaDesactiva(e, false);
		print("desactivado + " + e);
	}

}

[System.Serializable]
public class MisBooles
{
    public string etiqueta;
    public bool estado;

    public bool Comparar(string e)
	{
        return estado.Equals(e);
	}
}