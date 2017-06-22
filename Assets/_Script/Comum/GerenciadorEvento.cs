using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections.Generic;

[System.Serializable]
public class MeuEvento : UnityEvent<GameObject, string>
{
}

public class GerenciadorEvento : MonoBehaviour
{

	public static GerenciadorEvento instancia;
	private Dictionary<string, MeuEvento> eventos = new Dictionary<string,MeuEvento> ();

	public void OnDestroy ()
	{
		instancia = null;
	}

	public static void CarregarEvento (string nome, UnityAction<GameObject, string> evento)
	{
		if (instancia == null) {
			instancia = FindObjectOfType (typeof(GerenciadorEvento)) as GerenciadorEvento;
			if (instancia == null) {
				return;
			}
		}
		MeuEvento esteEvento = null;
		if (instancia.eventos.TryGetValue (nome, out esteEvento)) {
			esteEvento.AddListener (evento);
		} else {
			esteEvento = new MeuEvento ();
			esteEvento.AddListener (evento);
			instancia.eventos.Add (nome, esteEvento);
		}
	}

	public static void RemoverEvento (string nome, UnityAction<GameObject, string> evento)
	{
		if (instancia == null) {
			return;
		}
		MeuEvento esteEvento = null;
		if (instancia.eventos.TryGetValue (nome, out esteEvento)) {
			esteEvento.RemoveListener (evento);
		}
	}

	public static void ExecutarEvento (string nome, GameObject obj, string param)
	{
		if (instancia == null) {
			return;
		}
		MeuEvento esteEvento = null;
		if (instancia.eventos.TryGetValue (nome, out esteEvento)) {
			esteEvento.Invoke (obj, param);
		}
	}
}
