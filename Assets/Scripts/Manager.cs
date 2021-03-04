using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour, Timerble
{
	//public
	public List<GameObject> planttypes = new List<GameObject>();
	//resource related variables
	public int oxyticks = 0;
	public int[] resources;
	public Text waterCount;
	public int water = 0;
	//state related variables
	private bool shopping = false;
	private bool finished = false;
	public int heldseed = 1;
	public int heldtool = 0;

	void Start()
	{
        oxyticks = 0;
		shopping = false;
		finished = false;
		//RESOURCE ORDER: CHARM, MONEY, OXYGEN, WATER, CARBON, ENERGY, RUST, CHROME
		resources = new int[]{0, 0, 0, 0, 0, 0, 0, 0};
    }

    // Update is called once per frame
    void Update()
	{
		
    }
	
	public void timerUpdate(){
		//charm
		resources[0] = getcharm();
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
		return !(finished || shopping);
	}

	public void SetWater()
	{
		water++;
		waterCount.text = "Water: " + water;
	}
}
