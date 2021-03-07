using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToilRig : PlantBase, PlantCharming
{
    public int resourceticks = 2;
	public int killticks = 25;
	
	public override void thePlantUpdate(){
		resourceticks--;
		if(resourceticks <= 0){
			transform.localScale = new Vector3(1.5f, 0.5f, 0.5f);
			currentcolor = Color.Lerp(currentcolor, new Color(0.5f, 0.1f, 0f, 1f), 0.025f);
			resourceticks = 2;
			dirt.m.resources[2] += 1;
			dirt.m.resources[3] += 1;
			dirt.m.resources[4] += 1;
			killticks--;
			if(killticks <= 0){
				killThis();
			}
		}
	}
	
	public int returnCharm(){
		return -15;
	}
}
