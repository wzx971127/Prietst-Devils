using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paowu3 : MonoBehaviour {

	public float speed;
	// Use this for initialization
	void Start () {
        speed = 0;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 vec = new Vector3(Time.deltaTime * 5, -Time.deltaTime * (speed / 10), 0);
        speed++;
        transform.Translate(vec);
    }
}
