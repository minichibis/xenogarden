using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlantBase : MonoBehaviour, Timerble
{
	public DirtPatch dirt;
	//OK SO
	//returning plant output is probably going to be calculated through thePlantUpdate
	//charm will be done through an external script, through PlantCharming interface
	//upkeep will need the PlantUpkeep interface, although managing it might be a bear. We could probably do it in the timesignal update?
	
    // Start is called before the first frame update
    void Start()
    {
        
    }
	
	public virtual void timerUpdate(){
		thePlantUpdate();
	}
	
	public abstract void thePlantUpdate();
	
	public virtual void killThis(){
		dirt.p = null;
		TimeSignal t = Object.FindObjectOfType<TimeSignal>();
		t.removethis.Add(this);
		Destroy(gameObject);
	}
}
