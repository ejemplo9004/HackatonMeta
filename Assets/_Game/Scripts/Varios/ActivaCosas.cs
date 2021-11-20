using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivaCosas : MonoBehaviour
{
    public CosaActivable[] cosas;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		for (int i = 0; i < cosas.Length; i++)
		{
            cosas[i].objeto.SetActive(Controoleano.singleton.Buscar(cosas[i].etiqueta));
		}
    }

    public void Escuchar()
	{
        Orquestador.singleton.Escuchar();
	}
    public void ReproducirEjemplo()
	{
        Orquestador.singleton.ReproducirEjemplo();
	}

    public void Activar(string e)
    {
        Controoleano.singleton.ActivaDesactiva(e, true);
    }
    public void Desactivar(string e)
    {
        Controoleano.singleton.ActivaDesactiva(e, false);
    }

}
[System.Serializable]
public class CosaActivable
{
    public string etiqueta;
    public GameObject objeto;
}