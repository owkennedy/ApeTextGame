using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnumStateController : MonoBehaviour {

	public Text stateText;
	public Text dayText;
	public Text parentStatsText;
	public StatsController statsController;

	float health = 0.1f;
	int motherHealth;
	int fatherHealth;
	int food = 3;

	public int day;

	enum States {birth, parents_0, parents_1, parents_2, parents_3, single_mother0, single_mother1, single_mother2, single_mother3, parentless_0, parentless_1, death, win};

	private States myState;

	// Use this for initialization
	void Start () {

		myState = 				States.birth;

		day = 					0;
		motherHealth = 			100;
		fatherHealth = 			100;

		dayText.text = 			"Day: " + day;
		parentStatsText.text =	"Father's Health : " + fatherHealth + "\n" +
								"Mother's Health : " + motherHealth;

		statsController.GetComponent<StatsController> ();

		
	}
	
	// Update is called once per frame
	void Update () {
		print (myState);

		if (myState == States.birth) {
			Birth ();
		} else if (myState == States.parents_0) {
			Parents0 ();
		} else if (myState == States.parents_1) {
			Parents1 ();
		} else if (myState == States.parents_2) {
			Parents2 ();
		} else if (myState == States.parents_3) {
			Parents3 ();
		} else if (myState == States.single_mother0) {
			SingleMother0 ();
		} else if (myState == States.single_mother1) {
			SingleMother1 ();
		} else if (myState == States.single_mother2) {
			SingleMother2 ();
		} else if (myState == States.single_mother3) {
			SingleMother3 ();
		} else if (myState == States.parentless_0) {
			Parentless_0 ();
		} else if (myState == States.parentless_1) { 
			Parentless_1 ();
		} else if (myState == States.death) { 
			Death ();
		} else if (myState == States.win) {
			WinGame ();
		}

			

	}

	void Birth ()
	{
		stateText.text = 	"You have been born. You are an ape. It is 10 million years ago. You are very weak and there are dangers all around, but you also have your parents to protect you. If they die, so will you!\n\n" +
							"Will you survive for first 100 days?\n\n" +
							"Press 'ENTER' to continue";
		if (Input.GetKeyDown (KeyCode.Return)) {

			ParentsStateDecider ();
			DayCount ();
		}
	}

	void Parents0 ()
	{
		stateText.text =	"You and your family are safe and have enough to eat.\n\n" +
			"Press 'ENTER' to continue";

		if (Input.GetKeyDown (KeyCode.Return)) {
			DayCount ();
			ParentsStateDecider ();
		}
	}

	void Parents1 ()
	{
		stateText.text =	"You and your family are safe but there is no food to be found today.\n\n" +
			"Press 'ENTER' to continue";

		if (Input.GetKeyDown (KeyCode.Return)) {
			DayCount ();
			ParentsStateDecider ();
		}
	}

	void Parents2 ()
	{
		stateText.text =	"You and your family are not safe but there is food.\n\n" +
			"Press 'ENTER' to continue";

		if (Input.GetKeyDown (KeyCode.Return)) {
			DayCount ();
			ParentsStateDecider ();
		}
	}

	void Parents3 ()
	{
		stateText.text =	"You and your family are in danger and without food!\n\n" +
			"Press 'ENTER' to continue";

		if (Input.GetKeyDown (KeyCode.Return)) {
			DayCount ();
			ParentsStateDecider ();
		}
	}

	void SingleMother0 ()
	{
		stateText.text =	"You and your mother are safe and have enough to eat.\n\n" +
							"Press 'ENTER' to continue";

		if (Input.GetKeyDown (KeyCode.Return)) {
			DayCount ();
			SingleMotherStateDecider ();
		}
	}

	void SingleMother1 ()
	{
		stateText.text =	"You and your mother are safe but there is no food to be found today.\n\n" +
							"Press 'ENTER' to continue";

		if (Input.GetKeyDown (KeyCode.Return)) {
			DayCount ();
			SingleMotherStateDecider ();
		}
	}

	void SingleMother2 ()
	{
		stateText.text =	"You and your mother are not safe but there is food.\n\n" +
			"Press 'ENTER' to continue";
		
		if (Input.GetKeyDown (KeyCode.Return)) {
			DayCount ();
			SingleMotherStateDecider ();
		}
	}

	void SingleMother3 ()
	{
		stateText.text =	"You and your mother are in danger and without food!\n\n" +
			"Press 'ENTER' to continue";

		if (Input.GetKeyDown (KeyCode.Return)) {
			DayCount ();
			SingleMotherStateDecider ();
		}
	}

	void Parentless_0 ()
	{
		stateText.text = 	"You are hungry without your parents \n\n" +
			"Lose 1 Food\n\n" +
			"Press 'ENTER' to continue";
		if (Input.GetKeyDown (KeyCode.Return)) {
			DayCount ();
			ParentlessStateDecider ();
		}
	}

	void Parentless_1 ()
	{
		stateText.text = 	"You are attacked!\n\n" +
			"Lose 1 health\n\n" +
			"Press 'ENTER' to continue";
		if (Input.GetKeyDown (KeyCode.Return)) {
			DayCount ();
			ParentlessStateDecider ();
		}
	}

	void Death ()
	{
		stateText.fontSize = 40;
		stateText.text = 	"You are dead!";
		dayText.text = 		"You lasted " + day + " days.";
	}

	void WinGame ()
	{
			stateText.fontSize = 30;
		stateText.text = 	"You survived being a baby ape in this strange cruel world with for 100 days.\n\n" +
				"You Win!\n\n" +
				"CONGRATULATIONS!";
	}

	void ParentsStateDecider ()
	{
		float chance_0 = Random.value;
		print (chance_0);

		if (chance_0 >= 0.3f) {
			myState = States.parents_0;
			GainFatherHealth (5);
			GainMotherHealth (5);
		} else if (chance_0 >= 0.2f) {
			myState = States.parents_1;
			LoseFatherHealth (5);
			LoseMotherHealth (5);
		} else if (chance_0 >= 0.1f) {
			myState = States.parents_2;
			LoseFatherHealth (10);
		} else if (chance_0 <= 0.1f) {
			myState = States.parents_3; 
			LoseFatherHealth (20);
			LoseMotherHealth (10);
		} 

		if (day >= 100) {
			myState = States.win;
			print (day);
		} else if (day < 100)
			return;
	}


	void SingleMotherStateDecider ()
	{
		float chance_0 = Random.value;
		print (chance_0);

		if (day >= 100) {
			myState = States.win;
		} else if (chance_0 >= 0.6f) {
			myState = States.single_mother0;
			GainMotherHealth (5);
		} else if (chance_0 >= 0.4f) {
			myState = States.single_mother1;
			LoseMotherHealth (10);
		} else if (chance_0 >= 0.2f) {
			myState = States.single_mother2;
			LoseMotherHealth (20);
		} else if (chance_0 <= 0.2f) {
			myState = States.single_mother3; 
			LoseMotherHealth (30);
		} 
	}

	void ParentlessStateDecider ()
	{
		float chance_1 = Random.value;
		print (chance_1);

		if (day >= 100) {
			myState = States.win;
		} else if (chance_1 >= 0.5f) {
			myState = States.parentless_0;
			LoseFood ();
		} else if (chance_1 < 0.5f) {
			myState = States.parentless_1;
			LoseHealth ();
		}
	}

	void DeathState ()
	{
		myState = States.death;
	}

	void DayCount () {

		day++;
		dayText.text = "Day: " + day;

		if (( day % 30) == 0) {
			statsController.IncrementHealth (0.4f);
			health += 0.4f;
		}
	}

	void GainFatherHealth (int gainHealth)
	{
		fatherHealth += gainHealth;

		if (fatherHealth >= 100) {
			fatherHealth = 100;
		}

		parentStatsText.text =	"Father's Health : " + fatherHealth + "\n"  +
								"Mother's Health : " + motherHealth;
		}

	void GainMotherHealth (int gainHealth)
	{
		motherHealth += gainHealth;

		if (motherHealth >= 100) {
			motherHealth = 100;
		}
			
		parentStatsText.text =	"Father's Health : " + fatherHealth + "\n"  +
								"Mother's Health : " + motherHealth;
	}

	void LoseFatherHealth (int lostHealth)
	{
		fatherHealth -= lostHealth;

		parentStatsText.text =	"Father's Health : " + fatherHealth + "\n"  +
			"Mother's Health : " + motherHealth;

		if (fatherHealth <= 0) {
			SingleMotherStateDecider ();
			fatherHealth = 0;
		}
	}

	void LoseMotherHealth (int lostHealth)
	{
		motherHealth -= lostHealth;
		parentStatsText.text =	"Father's Health : " + fatherHealth + "\n"  +
			"Mother's Health : " + motherHealth;

		if (motherHealth <= 0) {
			ParentlessStateDecider ();
		}
	}

	void LoseFood ()
	{
		statsController.DecrementFood (1);
		food -= 1;

		if (food <= 0) {
			LoseHealth ();
		}
	}

	void LoseHealth ()
	{
			statsController.DecrementHealth (1);
			health -= 1f;

		if (health <= 0) {
			DeathState ();
		}
	}

}
