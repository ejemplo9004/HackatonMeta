using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camaleon : MonoBehaviour
{
    public static GameObject maestro;
    public static GameObject esclavo;
    public TipoCamaleon tipo;

    void Start()
    {
		switch (tipo)
		{
			case TipoCamaleon.maestro:
                maestro = gameObject;
                enabled = false;
                break;
			case TipoCamaleon.esclavo:
                esclavo = gameObject;
                gameObject.SetActive(false);
                enabled = false;
				break;
			default:
				break;
		}
	}

    // Update is called once per frame
    void FixedUpdate()
    {
		if (tipo==TipoCamaleon.arbitro && maestro != null && esclavo != null)
		{
            esclavo.SetActive(maestro.activeSelf);
		}
    }
}
public enum TipoCamaleon
{
    maestro,
    esclavo,
    arbitro
}
