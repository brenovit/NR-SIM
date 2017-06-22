using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObjetoTransacional;
using System.Linq;
using System;

public class DefaultData : MonoBehaviour
{
	private static List<Item> ListaIten ()
	{
		List<Item> lista = new List<Item> ();
		lista.Add (new Item () { ID = 1,	Nome = "extintor-sin-chao-err" });
		lista.Add (new Item () { ID = 2,	Nome = "extintor-sin-cor-err" });
		lista.Add (new Item () { ID = 3,	Nome = "extintor-alto-err" });
		lista.Add (new Item () { ID = 4,	Nome = "extintor-baixo-err" });
		lista.Add (new Item () { ID = 5,	Nome = "extintor-chao-err" });
		lista.Add (new Item () { ID = 6,	Nome = "extintor-chao-ok" });
		lista.Add (new Item () { ID = 7,	Nome = "extintor-sin-alto-err" });
		lista.Add (new Item () { ID = 8,	Nome = "extintor-sin-baixo-err" });
		lista.Add (new Item () { ID = 9,	Nome = "elevador-sin-alt-err" });
		lista.Add (new Item () { ID = 10,	Nome = "elevador-sin-err" });
		lista.Add (new Item () { ID = 11,	Nome = "elevador-sin-ok" });
		lista.Add (new Item () { ID = 12,	Nome = "porta-sin-err" });
		lista.Add (new Item () { ID = 13,	Nome = "porta-sin-cor-err" });
		lista.Add (new Item () { ID = 14,	Nome = "extintor-ok" });
		lista.Add (new Item () { ID = 15,	Nome = "porta-sin-cor-ok" });
		lista.Add (new Item () { ID = 16,	Nome = "porta-sin-ok" });
		lista.Add (new Item () { ID = 17,	Nome = "luminaria_desligada" });
		lista.Add (new Item () { ID = 18,	Nome = "luminaria_ligada" });
		lista.Add (new Item () { ID = 19,	Nome = "luminaria_ok" });
		return lista;
	}

	private static List<Pergunta> ListaPergunta ()
	{
		List<Pergunta> lista = new List<Pergunta> ();
		lista.Add (new Pergunta () {
			ID = 1,
			Descricao = "Esta sinalização de piso está correta?",
			Explicacao = "A sinalização de piso correta é vermelha com bordas amarelas.",
			NBR = "12693",
			Titulo = "Sistemas de proteção por extintores de incêndio"
		});
		lista.Add (new Pergunta () {
			ID = 2,
			Descricao = "A cor desta sinalização de parede está correta?",
			Explicacao = "A cor correta da sinalização de parede (placa) é vermelha.",
			NBR = "13434-1",
			Titulo = "Sinalização de segurança contra incêndio e pânico Parte 1: Princípios de projeto"
		});
		lista.Add (new Pergunta () {
			ID = 3,
			Descricao = "A altura desta sinalização de parede está correta?",
			Explicacao = "A altura correta da sinalização de parede do extintor é de 1,80m.",
			NBR = "13434-1",
			Titulo = "Sinalização de segurança contra incêndio e pânico Parte 1: Princípios de projeto"
		});
		lista.Add (new Pergunta () {
			ID = 4,
			Descricao = "A altura do extintor está correta?",
			Explicacao = "A altura do extintor não deve exceder 1,60m. A parte inferior deve ter no mínimo, 0,20m de distância do piso.",
			NBR = "12693",
			Titulo = "Sistemas de proteção por extintores de incêndio"
		});
		lista.Add (new Pergunta () {
			ID = 5,
			Descricao = "Esta sinalização está correta?",
			Explicacao = "A sinalização correta para porta com barras antipânico é verde, escrito “Aperte e empurre”, anexada na própria porta com altura de 1,20m.",
			NBR = "13434-1",
			Titulo = "Sinalização de segurança contra incêndio e pânico Parte 1: Princípios de projeto"
		});
		lista.Add (new Pergunta () {
			ID = 6,
			Descricao = "A sinalização acima dela está correta?",
			Explicacao = "A sinalização correta, a seta aponta para cima(frente), acima da porta com barras antipânico.",
			NBR = "13434-1",
			Titulo = "Sinalização de segurança contra incêndio e pânico Parte 1: Princípios de projeto"
		});
		lista.Add (new Pergunta () {
			ID = 7,
			Descricao = "No cénario atual, a luminária de emergência está correta?",
			Explicacao = "A luminária de emergência tem de estar conectada na tomada e apagada.",
			NBR = "10898",
			Titulo = "Sistema de iluminação de emergência"
		});
		lista.Add (new Pergunta () {
			ID = 8,
			Descricao = "Está sinalização está correta?",
			Explicacao = "A placa correta deve estar anexada ao lado do elevador a 1,80m do piso, escrito “Em caso de incêndio",
			NBR = "13434-1",
			Titulo = "Sinalização de segurança contra incêndio e pânico Parte 1: Princípios de projeto"
		});
		return lista;
	}

	private static List<Quiz> ListaQuiz ()
	{
		List<Quiz> lista = new List<Quiz> ();
		lista.Add (new Quiz (1, 1, 14, "extintor_sin_chao_1", true));
		lista.Add (new Quiz (2, 1, 1, "extintor_sin_chao_2", false));
		lista.Add (new Quiz (3, 2, 2, "extintor_sin_cor_1", true));
		lista.Add (new Quiz (4, 2, 2, "extintor_sin_cor_2", false));
		lista.Add (new Quiz (5, 5, 13, "porta_sin_cor_2", false));
		lista.Add (new Quiz (6, 5, 12, "porta_sin_cor_1", true));
		lista.Add (new Quiz (7, 4, 5, "extintor_alt_4", false));
		lista.Add (new Quiz (8, 4, 3, "extintor_alt_1", false));
		lista.Add (new Quiz (9, 4, 14, "extintor_alt_2", true));
		lista.Add (new Quiz (10, 4, 6, "extintor_alt_3", true));
		lista.Add (new Quiz (11, 3, 14, "extintor_sin_alt_1", true));
		lista.Add (new Quiz (12, 3, 7, "extintor_sin_alt_2", false));
		lista.Add (new Quiz (13, 3, 8, "extintor_sin_alt_3", true));
		lista.Add (new Quiz (14, 7, 18, "lumn_1", false));
		lista.Add (new Quiz (15, 7, 19, "lumn_2", true));
		lista.Add (new Quiz (16, 7, 17, "lumn_3", false));
		lista.Add (new Quiz (17, 6, 16, "porta_sin_top_1", true));
		lista.Add (new Quiz (18, 6, 12, "porta_sin_top_2", false));
		return lista;
	}

	/// <summary>
	/// Retorna uma lista com todos os arquivos padrões
	/// </summary>
	/// <returns>The default.</returns>
	public static List<Quiz> ObjetosDefault(){
		List<Item> listaItem = new List<Item> ();
		List<Pergunta> listaPergunta = new List<Pergunta> ();
		List<Quiz> listaQuiz = new List<Quiz> ();

		try{
			listaItem = DefaultData.ListaIten ();
			listaPergunta = DefaultData.ListaPergunta ();
			listaQuiz = DefaultData.ListaQuiz ();

			foreach (var quiz in listaQuiz) {
				Item item = listaItem.Where (i => i.ID == quiz.Item.ID).First ();
				quiz.Item = item;
				Pergunta pergunta = listaPergunta.Where (p => p.ID == quiz.Pergunta.ID).First ();
				quiz.Pergunta = pergunta;
			}
		}catch(Exception ex){
			print (ex.Message);		
		}

		return listaQuiz;
	}
}
