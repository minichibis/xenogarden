using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxyTuber : PlantBase, PlantCharming
{
    public int resourceticks = 5;
	public int killticks = 10;
	
	public override void thePlantUpdate(){
		resourceticks--;
		if(resourceticks <= 0){
			transform.localScale = new Vector3(1.5f, 0.5f, 0.5f);
			currentcolor = Color.Lerp(currentcolor, new Color(0.5f, 0.1f, 0f, 1f), 0.15f);
			resourceticks = 5;
			dirt.m.resources[2]+= 5;
			killticks--;
			if(killticks <= 0){
				killThis();
			}
		}
	}
	
	public int returnCharm(){
		return 5;
	}
}