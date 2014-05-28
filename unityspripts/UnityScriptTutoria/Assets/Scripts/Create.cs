using UnityEngine;
using System.Collections;



namespace HDScripte
{
	public class Create : MonoBehaviour {

		public Transform  newObject;

		// Use this for initialization
		void Start () {
		
		
		}
		
		// Update is called once per frame
		void Update () {

			if(Input.GetButtonDown("Fire1"))
			{

				Instantiate(newObject,transform.position,transform.rotation);
			}
		
		}
	}

}
