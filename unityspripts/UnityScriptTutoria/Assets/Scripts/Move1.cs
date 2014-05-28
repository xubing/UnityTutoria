using UnityEngine;
using System.Collections;

public class Move1 : MonoBehaviour {

	private float speed = 5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		//update the game by per seconds.
		float x = Input.GetAxis("Horizontal")*Time.deltaTime*speed;
		float z = Input.GetAxis("Vertical")*Time.deltaTime*speed;
		transform.Translate(x,0,z);

		//update by every frame
		//transform.Translate(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
	}
}
