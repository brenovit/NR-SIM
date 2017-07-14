using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SaveGameFree;
using ObjetoTransacional;
using ObjetosJogo;

public class DataManager : MonoBehaviour
{
	//Caution don't change this name
	public string fileName = "nbrSimData";

	//verifica se os dados existem
	//se existir, carrega os itens
	//se não, cria um novo

	//salvar os itens
	//verificar se ja foi alterado
	// Use this for initialization

	void Awake (){	
		Saver.Initialize (FormatType.XML);
	}

	/// <summary>
	/// Criars the arquivo default.
	/// </summary>
	public void CriarArquivoDefault(){
		DeletarArquivo (fileName);
		SalvarListaQuiz (fileName, DefaultData.ObjetosDefault());
	}

	public List<GameItemReflex> CarregarListaGameItemReflex(string sceneFileName){
		List<GameItemReflex> lista = Saver.Load<List<GameItemReflex>> (sceneFileName);
		return lista;
	}

	/// <summary>
	/// Carregar uma lista de Quiz presente num arquivo XML
	/// </summary>
	/// <returns>The lista.</returns>
	/// <param name="sceneFileName">Scene file name.</param>
	public List<Quiz> CarregarListaQuiz(string sceneFileName){
		List<Quiz> lista = Saver.Load<List<Quiz>> (sceneFileName);
		return lista;
	}

	/// <summary>
	/// Salva uma lista de quiz em um arquivo XML
	/// </summary>
	/// <param name="sceneFileName">Scene file name.</param>
	/// <param name="lista">Lista.</param>
	public void SalvarListaQuiz(string sceneFileName,List<Quiz> lista){
		Saver.Save (lista, sceneFileName);
	}

	public void SalvarListaGameItemReflex(string sceneFileName,List<GameItemReflex> lista){
		DeletarArquivo (sceneFileName);
		Saver.Save (lista, sceneFileName);
	}

	/// <summary>
	/// Deleta um arquivo fisico
	/// </summary>
	/// <param name="nomeArquivo">Nome arquivo.</param>
	public void DeletarArquivo(string nomeArquivo){
		Saver.DeleteFile (nomeArquivo);
	}
}
