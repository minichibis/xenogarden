using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellCheese : PlantBase, PlantCharming, PlantUpkeep
{
    int damaged = 0;
	int[] haves = new int[]{0, 0, 0, 5, 0, 0, 0, 0};
	int[] needs = new int[]{0, 0, 0, 1, 0, 0, 0, 0};
	public AudioClip water;

	public override void thePlantUpdate(){
		haves[3] = Mathf.Min(haves[3], 5);
		if(haves[3] >= 1){
			damaged--;
			damaged = Mathf.Max(damaged, 0);
			currentcolor = Color.white;
		}
	}
	
	public int returnCharm(){
		return 25;
	}
	
	public int[] returnUpkeepNeeds(){
		return needs;
	}
	
	public int[] returnUpkeepHas()
	{
		AudioSource.PlayClipAtPoint(water, transform.position, 1.0f);
		return haves;
	}
	
	public void damageUpkeep(){
		if(damaged > 2){
			killThis();
		}
		damaged++;
		GetComponent<Renderer>().material.color = Color.red;
		transform.localScale = new Vector3(1.5f, 0.5f, 0.5f);
		currentcolor = Color.Lerp(currentcolor, new Color(0.5f, 0.1f, 0f, 1f), 0.25f);
	}
}
