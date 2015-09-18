using UnityEngine;
using System.Collections;

public class StateControll : MonoBehaviour {
	
	public Sender[] allSenders;
	public Reciever[] allRecievers;

	public bool groupState;

	private void Awake(){

	}

	private void Start(){

		//Link to Recievers
		for(int i = 0; i < allRecievers.Length; i++){
//			allRecievers.
		}

		//Link to Senders
		for(int ii = 0; ii < allSenders.Length; ii++){

			allSenders[ii].localID = ii;
			allSenders[ii].linkedStateControll = this;


		}
	}

	public void GetChange(int _localID, bool _newState){

		bool _currentState = CheckSenders();
		if(groupState != _currentState){

			groupState = _currentState;

			for(int i = 0; i < allRecievers.Length; i++){
				allRecievers[i].Change(groupState);
			}
		}
	}

	private bool CheckSenders(){

		for(int i = 0; i < allSenders.Length; i++){

			if(!allSenders[i].state)
				return false;
		}

		return true;
	}

	//Link all partners
	private void OnDrawGizmos(){
		for(int i = 0; i < allRecievers.Length; i++){
			//			allRecievers.
			Gizmos.color = Color.blue;
			Gizmos.DrawLine(this.transform.position, allRecievers[i].transform.position);
		}
		
		//Link to Senders
		for(int ii = 0; ii < allSenders.Length; ii++){

			Gizmos.color = Color.yellow;
			Gizmos.DrawLine(this.transform.position, allSenders[ii].transform.position);
			
		}

	}
}
