using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{
	public int value = 1;
	
	
	void OnMouseDown(){
		Object.FindObjectOfType<Manager>().resources[1] += value;
		Destroy(gameObject);
	}
}
