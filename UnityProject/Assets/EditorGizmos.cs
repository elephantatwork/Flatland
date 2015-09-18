using UnityEngine;
using System.Collections;

public class EditorGizmos : MonoBehaviour {

//	public Mesh displayMesh;
	public string iconName;

	public Interactive localInteractive;

	private void Awake(){


	}

	private void OnDrawGizmos(){

//		localInteractive = this.GetComponent<Interactive>();
//
//		if(localInteractive != null){
//			print (localInteractive.state);
//			if(localInteractive.state)
//				Gizmos.color = Color.green;//Debug.instance.activeColor;
//			else
//				Gizmos.color = Color.red;//Debug.instance.inactiveColor;
//		}

		Gizmos.color = Color.green;
		Gizmos.DrawIcon(this.transform.position, iconName);
//		Gizmos.DrawMesh(displayMesh, this.transform.position);
	}
}
