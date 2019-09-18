using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paowu1 : MonoBehaviour {

	public float speed;
	// Use this for initialization
	void Start () {
        speed = 0;
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position += Vector3.right * Time.deltaTime * 5;
        this.transform.position += Vector3.down * Time.deltaTime * (speed/10);
        speed++;
	}
}
