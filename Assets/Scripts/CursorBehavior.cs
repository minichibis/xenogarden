using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorBehavior : MonoBehaviour
{
	public List<Sprite> spr = new List<Sprite>();
	public Manager m;
    // Update is called once per frame
    void Update(){
		Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mp.x, mp.y, -5);
		GetComponent<SpriteRenderer>().sprite = spr[m.heldtool];
    }
}
