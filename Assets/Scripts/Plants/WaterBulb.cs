﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBulb : PlantBase
{
    public int resourceticks = 3;
	public int killticks = 5;
	
	public override void thePlantUpdate(){
		resourceticks--;
		if(resourceticks <= 0){
			transform.localScale = new Vector3(1.5f, 0.5f, 0.5f);
			currentcolor = Color.Lerp(currentcolor, new Color(0.5f, 0.1f, 0f, 1f), 0.2f);
			resourceticks = 3;
			dirt.m.resources[3]++;
			killticks--;
			if(killticks <= 0){
				killThis();
			}
		}
	}
}
