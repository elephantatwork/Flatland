using UnityEngine;
using System.Collections;

public class Interactive : MonoBehaviour {

	public int localID;
	public bool state;
	
	public StateControll linkedStateControll;

	private Renderer localRenderer;

	void Awake () {
		localRenderer = this.GetComponent<Renderer>();
	}
	
	public virtual void Change(bool _newState){

		state = _newState;

		if(state)
			Activate();
		else
			Deactivate();
	}
	
	// Update is called once per frame
	public virtual void Activate () {
		
		localRenderer.material.color = Debug.instance.activeColor;
	}
	
	// Update is called once per frame
	public virtual void Deactivate () {
		localRenderer.material.color = Debug.instance.inactiveColor;
	}

}
