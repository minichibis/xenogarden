﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour, Timerble
{
	//LevelUI Reference
	public LevelUI levelUi;

	//stuff
	public CoinFactory coinf;
	//public
	public List<GameObject> planttypes = new List<GameObject>();
	//WATERBULB, OXYTUBER, PUFFSMILE, JELLCHEESE, CARBONVENT, TOIL RIG, CARBON GNOME
	public int[][] plantcosts = new int[][]{new int[]{0, 0, 3, 0, 0, 0, 0, 0},new int[]{0, 0, 10, 10, 0, 0, 0, 0},new int[]{0, 0, 15, 15, 0, 0, 0, 0},new int[]{0, 5, 10, 20, 0, 0, 0, 0},new int[]{0, 15, 25, 0, 0, 0, 0, 0},new int[]{0, 0, 20, 0, 5, 0, 0, 0},new int[]{0, 5, 0, 0, 5, 0, 0, 0}};
	
	public string[] tooltips = new string[]{
		"WATERBULB, the most basic plant. Has a short lifespan and provides water. Costs 3 OXYGEN to plant.", 
		"OXYTUBER, a root which taps into the ground and extracts oxygen. Some see it as beautiful. Costs 10 OXYGEN, 10 WATER to plant.", 
		"PUFFSMILE, a baloon-like plant with aesthetic appeal, that must be inflated using the oxy-injector to survive. Costs 15 OXYGEN, 15 WATER to plant.", 
		"JELLCHEESE, an odd plant which some consider beautiful. It must be watered regularly to survive. Costs 5 MONEY, 10 OXYGEN, 20 WATER to plant.", 
		"CARBONVENT, a plant that produces the rare industrial resource of carbon. It's appearance clashes quite hideously with other plants, however. Costs 15 MONEY 25 OXYGEN to plant.",
		"TOIL RIG, a literal industrial plant used to extract mass quantities of resources from the ground. Ugly but effective. Costs 20 OXYGEN, 5 CARBON to plant.", 
		"CARBON GNOME, a strange little plant with an infinite lifespan. Unlike other carbon plants it is seen as quite cute. Costs 5 MONEY 5 CARBON to plant.", 
		"SHOVEL, a basic tool for digging up unwanted plants.", 
		"OXY-INJECTOR, used to provide oxygen to plants that rely on it, like PUFFSMILES.", 
		"WATERING CAN, used to water plants that need it to live, like JELLCHEESE."};
	
	public Sprite[] toolimg;
	public GameObject photo;
	public Text tooltext;
	public Text restext;
	public Text wintext;
	//resource related variables
	public int oxyticks = 0;
	public int[] resources;
	public Text waterCount;
	public int water = 0;
	//state related variables
	private bool shopping = false;
	private bool finished = false;
	public int heldseed = 1;
	//TOOLS: none, shovel, oxy injector, watering can
	public int heldtool = 0;
	//coin related
	private int pennycharm = 0;
	private int nickelcharm = 0;
	public bool won = false;

	void Start()
	{
		pennycharm = 15;
		nickelcharm = 15;
        oxyticks = 0;
		shopping = false;
		finished = false;
		//RESOURCE ORDER: CHARM, MONEY, OXYGEN, WATER, CARBON, ENERGY, RUST, CHROME
		resources = new int[]{0, 0, 0, 0, 0, 0, 0, 0};
		won = false;
    }

    // Update is called once per frame
    void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1)){
			heldseed = 1;
			heldtool = 0;
		} else if (Input.GetKeyDown(KeyCode.Alpha2)){
			heldseed = 2;
			heldtool = 0;
		} else if (Input.GetKeyDown(KeyCode.Alpha3)){
			heldseed = 3;
			heldtool = 0;
		} else if (Input.GetKeyDown(KeyCode.Alpha4)){
			heldseed = 4;
			heldtool = 0;
		} else if (Input.GetKeyDown(KeyCode.Alpha5)){
			heldseed = 5;
			heldtool = 0;
		} else if (Input.GetKeyDown(KeyCode.Alpha6)){
			heldseed = 6;
			heldtool = 0;
		} else if (Input.GetKeyDown(KeyCode.Alpha7)){
			heldseed = 7;
			heldtool = 0;
		} else if (Input.GetKeyDown(KeyCode.Q)){
			heldseed = 0;
			heldtool = 1;
		} else if (Input.GetKeyDown(KeyCode.W)){
			heldseed = 0;
			heldtool = 2;
		} else if (Input.GetKeyDown(KeyCode.E)){
			heldseed = 0;
			heldtool = 3;
		}

		if (heldtool > 0)
		{
            #region Temporary Logic for setting name field
            if (heldtool == 1)
			{
				levelUi.setName("Shovel");
			}
			else if (heldtool == 2)
			{
				levelUi.setName("Watering Can");
			}
			else if (heldtool == 3)
			{
				levelUi.setName("Oxygen Injector");
			}
            #endregion

            //tooltext.text = "SELECTED: " + tooltips[heldtool + 6]; //Need swap panel to display full description
            photo.GetComponent<SpriteRenderer>().sprite = toolimg[heldtool + 6];
		} 
		else
		{
            #region Temporary Logic for setting name field
            if (heldseed == 1)
			{
				levelUi.setName("WaterBulb");
			}
			else if(heldseed == 2)
			{
				levelUi.setName("OxyTuber");
			}
			else if (heldseed == 3)
			{
				levelUi.setName("PuffSmile");
			}
			else if (heldseed == 4)
			{
				levelUi.setName("JellCheese");
			}
			else if (heldseed == 5)
			{
				levelUi.setName("CarbonVent");
			}
			else if (heldseed == 6)
			{
				levelUi.setName("ToilRig");
			}
			else if (heldseed == 7)
			{
				levelUi.setName("CarbonGnome");
			}
            #endregion

            //tooltext.text = "SELECTED: " + tooltips[heldseed - 1];
			photo.GetComponent<SpriteRenderer>().sprite = toolimg[heldseed - 1];
		}
		//Change to text script,, Move Goal at end to new text object
		restext.text = "RESOURCES \n CHARM : " + Mathf.Max(resources[0], 0) + " \n MONEY: " + resources[1] + " \n OXYGEN: " + resources[2] + " \n WATER: " + resources[3] + " \n CARBON " + resources[4] + " \n\nGAIN 50 MONEY TO WIN";

		//Change to text script
		wintext.text = "";
		if(resources[1] >= 50){
			//Change to text script
			wintext.text = "YOU WIN! Press R to Restart!";
			won = true;
		}
		if (Input.GetKeyDown(KeyCode.R)){
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
    }
	
	public void timerUpdate(){
		//charm
		pennycharm--;
		nickelcharm--;
		pennycharm = Mathf.Max(pennycharm, 0);
		nickelcharm = Mathf.Max(nickelcharm, 0);
		resources[0] = getcharm();
		coinmanage();
		//finished
		finished = getfinished();
		//oxytimer
		oxyticks++;
		if (oxyticks <= 2){
			resources[2]++;
			oxyticks = 0;
		}
	}
	
	private int getcharm()
	{
		int totalcharm = 0;
		PlantBase[] l = Object.FindObjectsOfType<PlantBase>();
		foreach(PlantBase p in l){
			if(p is PlantCharming){
				totalcharm += (p as PlantCharming).returnCharm();
			}
		}
		return totalcharm;
	}
	
	private bool getfinished()
	{
		//this will checks if the plants are in the right place for game completion
		return false;
	}
	
	public bool getworldinteract()
	{
		//this checks if world interaction is allowed
		return !won;
		//return !(finished || shopping);
	}

	public void SetWater()
	{
		water++;
		//Change to text script
		waterCount.text = "Water: " + water;
	}
	
	private void coinmanage(){
		if(Random.Range(0f, 30f) < 25){
			int c = Mathf.Max(resources[0] + 5 - pennycharm, 0);
			if(Random.Range(0f, 100f) <= c){
				pennycharm += 5;
				coinf.CoinMake(1);
			}
		} else{
			int c = Mathf.Max(resources[0] - 15 - nickelcharm, 0);
			if(Random.Range(0f, 100f) <= c){
				nickelcharm += 15;
				pennycharm += 5;
				coinf.CoinMake(2);
			}
		}
	}
}
