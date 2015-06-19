using UnityEngine;
using System.Collections;

public class Bewegen : MonoBehaviour
{
	
	// public member eines Scripts können bequem
	// im Unity Editor gesetzt und auch während
	// das Spiel getestet wird verändert werden.
	
	public float Geschwindigkeit;
	public float Beschleunigung;
	
	
	float aktuelleGeschwindigkeit = 0;
	Vector3 richtung = Vector3.zero;
	
	void Start()
	{
	}
	
	void Update()
	{
		if (EingabeÜberprüfen())
		{
			if (aktuelleGeschwindigkeit < Geschwindigkeit)
			{
				aktuelleGeschwindigkeit += Beschleunigung * Time.deltaTime;
			}
			this.transform.position += richtung * aktuelleGeschwindigkeit * Time.deltaTime;
		}
		else
		{
			aktuelleGeschwindigkeit = 0f;
		}
	}
	
	private bool EingabeÜberprüfen()
	{
		bool eingabe = false;
		float x = 0f;
		float z = 0f;
		
		
		// Input.GetKey gibt true zurück wenn
		// die gefragte Taste gedrückt ist
		

		if (Input.GetKey(KeyCode.UpArrow))
		{
			z++;
			eingabe = true;
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			z--;
			eingabe = true;
		}
		richtung = new Vector3(x, 0f, z);
		return eingabe;
	}
}
