using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
	//resource related variables
	private float oxytime = 0.0f;
	public int[] resources;
	//state related variables
	private bool shopping = false;
	private bool finished = false;
	private float checktime = 0.0f;
	
	
    void Start(){
        oxytime = 0.0f;
		checktime = 0.0f;
		shopping = false;
		finished = false;
		//RESOURCE ORDER: CHARM, MONEY, OXYGEN, WATER, CARBON, ENERGY, RUST, CHROME
		resources = new int[]{0, 0, 0, 0, 0, 0, 0, 0};
    }

    // Update is called once per frame
    void Update(){
		//gain oxygen every 3 seconds
        oxytime += Time.deltaTime;
		if (oxytime <= 3.0f){
			oxytime = 0.0f;
			resources[2]++;
		}
		//check several vital things only now and again so we dont loop over every plant every frame
		checktime += Time.deltaTime;
		if(checktime <= 1.0f){
			checktime = 0.0f;
			resources[0] = getcharm();
			finished = getfinished();
			
		}
    }
	
	private int getcharm(){
		//this will go over all plants and add their charm
		return 0;
	}
	
	private bool getfinished(){
		//this will checks if the plants are in the right place for game completion
		return false;
	}
	
	public bool getworldinteract(){
		//this checks if world interaction is allowed
		return !(finished || shopping);
	}
}
