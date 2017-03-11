using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(BoxCollider2D))]
public class UiBlock : MonoBehaviour
{
	public static BoxCollider2D bxCol;

	void Start ()
	{
		bxCol = this.GetComponent <BoxCollider2D> ();
		if (bxCol != null) {
			bxCol.enabled = false;
		}
	}

	public static void Ativar ()
	{
		if (bxCol != null) {
			bxCol.enabled = true;
		}
	}

	public static void Desativar ()
	{
		if (bxCol != null) {
			bxCol.enabled = false;
		}
	}

	public static void Alterar (bool estado)
	{
		if (bxCol != null) {
			bxCol.enabled = estado;
		}
	}

}
