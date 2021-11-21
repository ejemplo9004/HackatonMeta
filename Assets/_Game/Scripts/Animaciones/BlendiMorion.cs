using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendiMorion : MonoBehaviour
{
    public SkinnedMeshRenderer malla;
	public int iteraciones = 10;
	public float pausas = 0.1f;
	public float estado = 0;
    public void Activar(int nombre)
	{
		StartCoroutine(Activando(100, nombre));
	}
	public void Desactivar(int nombre)
	{
		StartCoroutine(Activando(0, nombre));
	}


	IEnumerator Activando(float a, int cual)
	{
		for (int i = 0; i < iteraciones; i++)
		{
			estado = Mathf.Lerp(estado, a, 0.3f);
			malla.SetBlendShapeWeight(cual, estado);
			yield return new WaitForSeconds(pausas);
		}
	}
}
