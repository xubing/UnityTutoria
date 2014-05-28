using UnityEngine;
using System.Collections;

namespace HDScripte
{
public class Switch : MonoBehaviour {

	public Transform switchToTarget;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
	if(Input.GetButtonDown("Jump"))
		{
				Follow follow =	(Follow)GetComponent("Follow");
			follow.target = switchToTarget;
		}

	}
}

}
