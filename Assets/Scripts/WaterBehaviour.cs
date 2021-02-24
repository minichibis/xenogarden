using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBehaviour : MonoBehaviour
{
    private GameObject gcObject;
    private Manager gc;

    // Start is called before the first frame update
    void Start()
    {
        gcObject = GameObject.Find("Manager");
        gc = gcObject.GetComponent<Manager>();
        //Cursor.lockState = CursorLockMode.Confined;
    }

    void OnMouseDown()
    {
        gc.SetWater();
        Destroy(gameObject);
    }
}