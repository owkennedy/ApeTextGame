using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsController : MonoBehaviour {

	float health = 0.1f;
	int food = 3;

	public Text statsText;

	// Use this for initialization
	void Start () {

		health = 0.1f;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DecrementFood (int lostFood)
	{
		food -= lostFood;
		UpdateStats ();
	}

	public void IncrementHealth (float extraHealth)
	{
		health += extraHealth;
		UpdateStats ();
	}

	public void DecrementHealth (float lostHealth)
	{
			health -= lostHealth;
			UpdateStats ();
	}

	public void UpdateStats ()
	{
		statsText.text = "Health : " + health + "\n" +
		"Food : " + food;
	}
}

