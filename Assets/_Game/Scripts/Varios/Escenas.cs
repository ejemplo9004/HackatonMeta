using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Escenas : MonoBehaviour
{
    public Image imFondo;

    public static Escenas singleton;

	private void Start()
	{
		StartCoroutine(FadeOut());
	}

	public void CambiarEscena(string nombre)
	{
		StartCoroutine(CambiarEscenaCR(nombre));
	}

	IEnumerator FadeOut()
	{
		for (int i = 0; i <= 20; i++)
		{
			yield return new WaitForSeconds(0.02f);
			imFondo.color = new Color(0, 0, 0, 1 - i / 20f);
		}
	}

    IEnumerator CambiarEscenaCR(string nombre)
	{
		for (int i = 0; i <= 20; i++)
		{
			yield return new WaitForSeconds(0.02f);
			imFondo.color = new Color(0, 0, 0, i / 20f);
		}
		SceneManager.LoadScene(nombre);
	}
}
