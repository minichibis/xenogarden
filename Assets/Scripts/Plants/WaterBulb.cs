using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBulb : PlantBase
{
    public int resourceticks = 3;
	public int killticks = 5;
	
	public override void thePlantUpdate(){
		resourceticks--;
		if(resourceticks <= 0){
			resourceticks = 3;
			dirt.m.resources[3]++;
			killticks--;
			if(killticks <= 0){
				killThis();
			}
		}
	}
}
