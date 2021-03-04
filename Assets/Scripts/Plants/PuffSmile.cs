using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuffSmile : PlantBase, PlantCharming, PlantUpkeep
{
    int damaged = 0;
	int[] haves = new int[]{0, 0, 0, 12, 0, 0, 0, 0};
	int[] needs = new int[]{0, 0, 0, 2, 0, 0, 0, 0};

    public override void thePlantUpdate(){
		haves[3] = Mathf.Min(haves[3], 12);
		if(haves[3] >= 2){
			damaged--;
			damaged = Mathf.Max(damaged, 0);
			currentcolor = Color.Lerp(currentcolor, Color.white, 0.25f);
		}
	}
	
	public int returnCharm(){
		return 25;
	}
	
	public int[] returnUpkeepNeeds(){
		return needs;
	}
	
	public int[] returnUpkeepHas(){
		return haves;
	}
	
	public void damageUpkeep(){
		Debug.Log("a");
		if(damaged > 2){
			killThis();
		}
		damaged++;
		GetComponent<Renderer>().material.color = Color.red;
		transform.localScale = new Vector3(1.5f, 0.5f, 0.5f);
		currentcolor = Color.Lerp(currentcolor, new Color(0.5f, 0.1f, 0f, 1f), 0.25f);
	}
}
