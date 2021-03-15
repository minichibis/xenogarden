using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlantBase : MonoBehaviour, Timerble
{
	public DirtPatch dirt;
	public Color currentcolor = Color.white;
	//OK SO
	//returning plant output is probably going to be calculated through thePlantUpdate
	//charm will be done through an external script, through PlantCharming interface
	//upkeep will need the PlantUpkeep interface, although managing it might be a bear. We could probably do it in the timesignal update?

	// Start is called before the first frame update
	void Start()
    {
        
    }
	
	void Update(){
		transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, 0.1f);
		GetComponent<Renderer>().material.color = Color.Lerp(GetComponent<Renderer>().material.color, currentcolor, 0.05f);
	}
	
	public virtual void timerUpdate(){
		thePlantUpdate();
	}
	
	public abstract void thePlantUpdate();
	
	public virtual void killThis(){
		dirt.p = null;
		TimeSignal t = Object.FindObjectOfType<TimeSignal>();
		t.removethis.Add(this);
		if(this is PlantCharming){
			dirt.m.resources[0] -= (this as PlantCharming).returnCharm();
		}
		Destroy(gameObject);
	}
}
