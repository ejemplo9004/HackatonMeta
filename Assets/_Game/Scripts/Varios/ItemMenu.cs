using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemMenu : MonoBehaviour
{
    public UnityEvent evento;
    public string tag = "Player";

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag(tag))
		{
			evento.Invoke();
		}
	}
}
