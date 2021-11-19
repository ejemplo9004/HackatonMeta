using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Textigo : MonoBehaviour
{
    public string etiqueta;
    public Text txtReferencia;
    Text txtPropio;
    void Start()
    {
        txtPropio = GetComponent<Text>();
        Inputexto[] inputextos = GameObject.FindObjectsOfType<Inputexto>();
		for (int i = 0; i < inputextos.Length; i++)
		{
			if (inputextos[i].etiqueta.Equals(etiqueta))
			{
                txtReferencia = inputextos[i].GetComponent<Text>();
			}
		}
    }

	private void FixedUpdate()
	{
		if (txtPropio == null || txtReferencia == null)
		{
			return;
		}
		txtPropio.text = txtReferencia.text;
		txtPropio.color = txtReferencia.color;
	}
}
