using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtPatch : MonoBehaviour
{
	public Material m1;
	public Material m2;
	public Manager m;
	public DirtFactory f;
	public PlantBase p;
    // Start is called before the first frame update
    void Start(){
        m = Object.FindObjectOfType<Manager>();
		f = Object.FindObjectOfType<DirtFactory>();
		p = null;
    }

    // Update is called once per frame
    void Update(){
        
    }
	
	void OnMouseOver(){
		if(p == null){
			GetComponent<Renderer>().material = m2;
		}
	}
	
	void OnMouseExit(){
		GetComponent<Renderer>().material = m1;
	}
	
	void OnMouseDown(){
		int[] cost = m.plantcosts[m.heldseed - 1];
		if(p == null && resourcecheck(cost)){
			for (int i = 0; i < 8; i++){
				m.resources[i] -= cost[i];
			}
			p = f.MakePlant(this, m.heldseed);
			GetComponent<Renderer>().material = m1;
		}
	}
	
	private bool resourcecheck(int[] cost){
		for (int i = 0; i < 8; i++){
			if (cost[i] > m.resources[i]) return false;
		}
		return true;
	}
}
