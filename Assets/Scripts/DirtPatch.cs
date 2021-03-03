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
		if(p == null && m.resources[2] >= 3){
			m.resources[2] -= 3;
			p = f.MakePlant(this, 1);
			GetComponent<Renderer>().material = m1;
		}
	}
}
