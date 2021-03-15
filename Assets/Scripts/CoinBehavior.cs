using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{
	public int value = 1;
	public AudioClip collect;


	void OnMouseDown(){
		Object.FindObjectOfType<Manager>().resources[1] += value;
		AudioSource.PlayClipAtPoint(collect, transform.position, 1.0f);
		Destroy(gameObject);
	}
}
