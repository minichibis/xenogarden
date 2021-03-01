using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSignal : MonoBehaviour
{
    private float timer = 0.0f;
	private float interval = 1.5f;
	
	public List<Timerble>observers = new List<Timerble>();
	
	void Update(){
		timer += Time.deltaTime;
		if(timer >= interval){
			timer -= interval;
			foreach(Timerble t in observers){
				
			}
		}
	}
}
