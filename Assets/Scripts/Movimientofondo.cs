using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimientofondo : MonoBehaviour
{
	public GameObject fondoMar;
	public float velocidad;
	private Vector3 direccion = Vector3.left;

	public GameManager pararBasura;

	public GameObject[] gruposDeBasura;


	//Cogemos el GameManager para poder manejar el ratio de la basura
	private void Start()
    {
		velocidad = 0;
		pararBasura = GameObject.Find("GameManager").GetComponent<GameManager>();
		
	}

    // Update is called once per frame
    void Update()
	{

		//Detenemos el fondo y aumentamos tanto la espera de la basura que no spawnea
		if (fondoMar.transform.position.x <= -10)
		{
			
			pararBasura.delay = 9999;
		}
		//Detenemos el fondo y aumentamos tanto la espera de la basura que no spawnea
		if (fondoMar.transform.position.x <= -21)
		{
			velocidad = 0;
			pararBasura.infoImage.gameObject.SetActive(true);
			int winText = Random.Range(0, pararBasura.winInfo.Length);
			pararBasura.infoText.text = pararBasura.winInfo[winText] + ".";
		}


		




		fondoMar.transform.Translate(direccion * Time.deltaTime * velocidad);

	}
}
