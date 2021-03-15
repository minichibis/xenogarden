using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtFactory : MonoBehaviour
{
	private Manager m;
	private TimeSignal t;
	public AudioClip planting;

	void Start(){
		m = Object.FindObjectOfType<Manager>();
		t = Object.FindObjectOfType<TimeSignal>();
	}
	
    public PlantBase MakePlant(DirtPatch d, int type){
		PlantBase p = null;
		if(type == 1){
			p = Instantiate(m.planttypes[0]).GetComponent<PlantBase>();
		}else if(type == 2){
			p = Instantiate(m.planttypes[1]).GetComponent<PlantBase>();
		}else if(type == 3){
			p = Instantiate(m.planttypes[2]).GetComponent<PlantBase>();
		}else if(type == 4){
			p = Instantiate(m.planttypes[3]).GetComponent<PlantBase>();
		}else if(type == 5){
			p = Instantiate(m.planttypes[4]).GetComponent<PlantBase>();
		}else if(type == 6){
			p = Instantiate(m.planttypes[5]).GetComponent<PlantBase>();
		}else if(type == 7){
			p = Instantiate(m.planttypes[6]).GetComponent<PlantBase>();
		}
		AudioSource.PlayClipAtPoint(planting, d.transform.position, 1.0f);
		p.transform.position = new Vector3(d.transform.position.x, d.transform.position.y, -1);
		p.dirt = d;
		t.observers.Add(p);
		return p;
	}
}
