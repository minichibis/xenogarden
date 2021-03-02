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
				t.timerUpdate();
				if(t is PlantUpkeep){
					bool damage = false;
					PlantUpkeep p = t as PlantUpkeep;
					int[] n = p.returnUpkeepNeeds();
					int[] h = p.returnUpkeepHas();
					for(int i = 2; i < h.Length; i++){
						h[i] -= n[i];
						if(h[i] < 0){
							h[i] = 0;
							damage = true;
						}
					}
					if(damage){
						p.damageUpkeep();
					}
				}
			}
		}
	}
}
