using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSignal : MonoBehaviour, Subject
{
    private float timer = 0.0f;
	private float interval = 1.5f;
	private bool tickneed = false;
	
	public List<Timerble>observers = new List<Timerble>();
	public List<Timerble>removethis = new List<Timerble>();
	
	void Start(){
       observers.Add(Object.FindObjectOfType<Manager>());
    }
	
	void Update(){
		if(!(observers[0] as Manager).won){
			timer += Time.deltaTime;
			if(timer >= interval){
				timer -= interval;
				removeObserver();
				notifyObservers();
				tickneed = !tickneed;
			}
		}
	}

    public void notifyObservers()
    {
		foreach (Timerble t in observers)
		{
			t.timerUpdate();
			if (tickneed && t is PlantUpkeep)
			{
				
				bool damage = false;
				PlantUpkeep p = t as PlantUpkeep;
				int[] n = p.returnUpkeepNeeds();
				int[] h = p.returnUpkeepHas();
				for (int i = 2; i < h.Length; i++)
				{
					h[i] -= n[i];
					if (h[i] < 0)
					{
						h[i] = 0;
						damage = true;
					}
				}
				if (damage)
				{
					p.damageUpkeep();
				}
			}
		}
	}

    public void removeObserver()
    {
		//remove
		foreach (Timerble t in removethis)
		{
			observers.Remove(t);
		}
		removethis = new List<Timerble>();
	}
}
