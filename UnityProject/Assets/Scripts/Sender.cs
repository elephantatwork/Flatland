using UnityEngine;
using System.Collections;

public class Sender : Interactive {


	private void OnMouseDown(){

		Change(!state);
	}

	public override void Change (bool _newState)
	{
		base.Change (_newState);

		linkedStateControll.GetChange(localID, state);

	}
}
