using UnityEngine;
using System.Collections;

public class Debug : MonoBehaviour {

	public static Debug instance {get; private set;}

	public Color activeColor;
	public Color inactiveColor;


	void Awake(){
		instance = this;
	}
}
