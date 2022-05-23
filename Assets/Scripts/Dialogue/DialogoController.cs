using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogoController : MonoBehaviour {

	public GameObject painelDeDialogo;

	public Text falaNPC;

	private bool falaAtiva = false;

	FalaNPC falas;
	
	public FalaNPC[] falasComeco = new FalaNPC[4];

	private bool dialogoConcluido = false;

	// Use this for initialization
	void Start () {
		if (ScoreManager.GetGeneral() < falasComeco.Length){
			StartDialog(ScoreManager.GetGeneral());
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetMouseButtonDown(0) && falaAtiva)
		{
			falaAtiva = false;
			painelDeDialogo.SetActive(false);
			falaNPC.gameObject.SetActive(false);
			FindObjectOfType<Player>().speed = 10;

		}

	}

	public void ProximaFala(FalaNPC fala)
	{
		falas = fala;

		falaAtiva = true;
		painelDeDialogo.SetActive(true);
		falaNPC.gameObject.SetActive(true);

		falaNPC.text = falas.fala;
	}
	
	public void StartDialog(int general){
		FindObjectOfType<Player>().speed = 0;
		if (!dialogoConcluido)
		{
			ProximaFala(falasComeco[general]);
		}
		else
		{
			ProximaFala(falasComeco[general]);
		}

		dialogoConcluido = true;

	}
}
