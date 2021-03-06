using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarbonVent : PlantBase, PlantCharming
{
    public int resourceticks = 10;
	public int killticks = 10;
	
	public override void thePlantUpdate(){
		resourceticks--;
		if(resourceticks <= 0){
			transform.localScale = new Vector3(1.5f, 0.5f, 0.5f);
			currentcolor = Color.Lerp(currentcolor, new Color(0.5f, 0.1f, 0f, 1f), 0.05f);
			resourceticks = 10;
			dirt.m.resources[4] += 1;
			killticks--;
			if(killticks <= 0){
				killThis();
			}
		}
	}
	
	public int returnCharm(){
		return -10;
	}
}
