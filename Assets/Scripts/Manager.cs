using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour, Timerble
{
	//stuff
	public CoinFactory coinf;
	//public
	public List<GameObject> planttypes = new List<GameObject>();
	public int[][] plantcosts;
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

	void Start()
	{
		pennycharm = 0;
		nickelcharm = 0;
        oxyticks = 0;
		shopping = false;
		finished = false;
		//RESOURCE ORDER: CHARM, MONEY, OXYGEN, WATER, CARBON, ENERGY, RUST, CHROME
		resources = new int[]{0, 0, 0, 0, 0, 0, 0, 0};
		//WATERBULB, OXYTUBER, PUFFSMILE, JELLCHEESE
		plantcosts = new int[][]{new int[]{0, 0, 3, 0, 0, 0, 0, 0},new int[]{0, 0, 10, 10, 0, 0, 0, 0},new int[]{0, 3, 15, 15, 0, 0, 0, 0},new int[]{0, 10, 10, 20, 0, 0, 0, 0}};
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
		return !(finished || shopping);
	}

	public void SetWater()
	{
		water++;
		waterCount.text = "Water: " + water;
	}
	
	private void coinmanage(){
		if(Random.Range(0f, 30f) < 25){
			int c = Mathf.Max(resources[0] + 5 - pennycharm, 0);
			if(Random.Range(0f, 100f) <= c){
				pennycharm += 10;
				coinf.CoinMake(1);
			}
		} else{
			int c = Mathf.Max(resources[0] - 15 - nickelcharm, 0);
			if(Random.Range(0f, 100f) <= c){
				nickelcharm += 15;
				pennycharm += 10;
				coinf.CoinMake(2);
			}
		}
	}
}
