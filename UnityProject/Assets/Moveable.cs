using UnityEngine;
using System.Collections;

public class Moveable : MonoBehaviour {

	private Rigidbody localRigidbody;

	// Use this for initialization
	void Start () {
	
		localRigidbody = this.gameObject.AddComponent<Rigidbody>();


	}
}
