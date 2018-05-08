using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right : MonoBehaviour {

    public float speed;

    // Use this for initialization
    void Start () {
        speed = 4;
        Debug.Log("test");
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.right * speed);
        Debug.Log("test");
    }
}
