using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuffSmile : PlantBase, PlantCharming, PlantUpkeep
{
    int damaged = 0;
	int[] haves = new int[]{0, 0, 12, 0, 0, 0, 0, 0};
	int[] needs = new int[]{0, 0, 2, 0, 0, 0, 0, 0};
	public AudioClip spray;

	public override void thePlantUpdate(){
		haves[2] = Mathf.Min(haves[2], 12);
		if(haves[2] >= 2){
			damaged--;
			damaged = Mathf.Max(damaged, 0);
			currentcolor = Color.white;
		}
	}
	
	public int returnCharm(){
		return 10;
	}
	
	public int[] returnUpkeepNeeds(){
		return needs;
	}
	
	public int[] returnUpkeepHas()
	{
		return haves;
	}
	
	public void damageUpkeep(){
		if(damaged > 2){
			killThis();
		}
		//AudioSource.PlayClipAtPoint(spray, transform.position, 1.0f);
		damaged++;
		GetComponent<Renderer>().material.color = Color.red;
		transform.localScale = new Vector3(1.5f, 0.5f, 0.5f);
		currentcolor = Color.Lerp(currentcolor, new Color(0.5f, 0.1f, 0f, 1f), 0.25f);
	}
}
