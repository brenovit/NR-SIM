using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using SaveGameFree.Serializers;
using ObjetoTransacional;
using System;

namespace SaveGameFree
{
	public class Demo : MonoBehaviour
	{
		public DemoData demoData;
		public string fileName = "gameData";
		List<Quiz> lista = null;
		/// <summary>
		/// Use awake function to initialize our game save and load.
		/// </summary>
		void Awake ()
		{
			Saver.OnSaved += Saver_OnSaved;
			Saver.OnLoaded += Saver_OnLoaded;

			// Initialize our game data
			demoData = new DemoData ();
			lista = new List<Quiz> ();

			// Initialize the Saver with the default configurations
			Saver.Initialize (FormatType.XML);

			// Load game data after initialization
			//demoData = Saver.Load<DemoData> (fileName);
			lista = Saver.Load<List<Quiz>> (fileName);
			print ("Carreguei a lista:" + lista.Count ());
		}

		void Saver_OnLoaded (object obj)
		{
			Debug.Log ("Loaded Successfully: " + lista.Count ());
		}

		void Saver_OnSaved (object obj)
		{
			Debug.Log ("Saved Succesfully: " + lista.Count ());
		}

		void OnGUI ()
		{
			GUILayout.Label ("This will get saved automatically when you change or input.");
			if (GUILayout.Button (string.Format ("Click Count: {0}", demoData.clickCount))) {
				demoData.clickCount++;
			}
			demoData.yourName = GUILayout.TextField (demoData.yourName);
			if (GUILayout.Button ("Save")) {
				// Save the game data
				//Saver.Save (demoData, fileName);
				List<Quiz> listaQuiz = DefaultData.ObjetosDefault ();
				Saver.Save (listaQuiz, fileName);
				print ("Salvei uma lista:" + listaQuiz.Count ());
			}
			if (GUILayout.Button ("Load")) {
				// Load the game data
				lista = Saver.Load<List<Quiz>> (fileName);
				print ("Carreguei a lista:" + lista.Count ());
			}
			if (GUILayout.Button ("Reload")) {
				//Application.LoadLevel (Application.loadedLevel);
			}
		}
	}
}