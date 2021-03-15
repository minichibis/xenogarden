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
	public AudioClip water;
	public AudioClip spray;
	public AudioClip dig;
	public AudioClip error;
    // Start is called before the first frame update
    void Start(){
		p = null;
    }

    // Update is called once per frame
    void Update(){
        
    }
	
	void OnMouseOver(){
		if(checkmousey()){
			GetComponent<Renderer>().material = m2;
		} else{
			GetComponent<Renderer>().material = m1;
		}
	}
	
	void OnMouseExit(){
		GetComponent<Renderer>().material = m1;
	}
	
	void OnMouseDown(){
		if(!m.won){
			if(m.heldtool == 0){
				int[] cost = m.plantcosts[m.heldseed - 1];
				if(p == null && resourcecheck(cost)){
					for (int i = 0; i < 8; i++){
						m.resources[i] -= cost[i];
					}
					p = f.MakePlant(this, m.heldseed);
					GetComponent<Renderer>().material = m1;
				}else if(p == null){
					AudioSource.PlayClipAtPoint(error, transform.position, 1.0f);
				}
			} else if(m.heldtool == 1 && p != null){
				AudioSource.PlayClipAtPoint(dig, transform.position, 1.0f);
				p.killThis();
			} else if(checkmousey()){
				addresource(p as PlantUpkeep, m.heldtool);
			}
		}
	}
	
	private bool resourcecheck(int[] cost){
		for (int i = 1; i < 8; i++){
			if (cost[i] > m.resources[i]) return false;
		}
		return true;
	}
	
	private bool checkmousey(){
		if (m.heldseed > 0 && p == null) return true;
		if(m.heldtool == 1 && p != null) return true;
		if(m.heldtool > 1 && p is PlantUpkeep){
			PlantUpkeep pl = p as PlantUpkeep;
			if(m.heldtool == 2 && pl.returnUpkeepNeeds()[2] > 0){
				return true;
			} else if(m.heldtool == 3 && pl.returnUpkeepNeeds()[3] > 0){
				return true;
			}
		}
		return false;
	}
	
	private void addresource(PlantUpkeep pl, int r){
		int addthis = Mathf.Min(m.resources[r], 5);
		pl.returnUpkeepHas()[r] += addthis;
		m.resources[r] -= addthis;
		if(addthis > 0){
			if(r == 2){
				AudioSource.PlayClipAtPoint(spray, transform.position, 1.0f);
			}else{
				AudioSource.PlayClipAtPoint(water, transform.position, 1.0f);
			}
		}
	}
	
}
