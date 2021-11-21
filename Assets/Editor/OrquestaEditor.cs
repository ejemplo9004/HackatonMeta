using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Orquesta))]
public class OrquestaEditor : Editor
{
	public override void OnInspectorGUI()
	{
		Orquesta o = (Orquesta)target;
		if (GUILayout.Button("Entrar"))
		{
			o.Entrar();
		}
		if (GUILayout.Button("Salir"))
		{
			o.Salir();
		}
		base.OnInspectorGUI();
	}
}
