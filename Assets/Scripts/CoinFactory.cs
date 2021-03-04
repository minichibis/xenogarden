using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinFactory : MonoBehaviour
{
	public List<GameObject> coins = new List<GameObject>();
    

    public void CoinMake(int type){
		GameObject c = Instantiate(coins[type - 1]);
		c.transform.position = new Vector3(Random.Range(-4f, 4f),6f,-1.5f);
		c.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-10f, 10f), Random.Range(-8f, -18f), 0f));
		c.GetComponent<Rigidbody>().AddTorque(new Vector3(0f, 0f, Random.Range(-5f, 5f)));
	}
}
