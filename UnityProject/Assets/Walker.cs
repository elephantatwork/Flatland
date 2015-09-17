using UnityEngine;
using System.Collections;

public class Walker : MonoBehaviour {

	private float currentWalkSpeed;

	public float normalWalk;
	public float fastWalk;

	private float currentStrafeSpeed;

	public float normalStrafe;
	public float fastStrafe;

	private float currentRotationSpeed; // Used as degrees per second

	public float normalRotation;
	public float fastRotation;

	private Vector3 moveVector;

	private Transform localTransform;

	public ArrivingWorldIntro _linkToINTRO;

	// Use this for initialization
	void Start () {
	
		localTransform = this.transform;

		ToggleFast(false);	
	}
	
	// Update is called once per frame
	void Update () {
	
	
		if(Input.GetKey(KeyCode.Q))
			Turn(-1);

		if(Input.GetKey(KeyCode.E))
			Turn(1);

		if(Input.GetKey(KeyCode.W))
			Move(1);

		if(Input.GetKey(KeyCode.S))
			Move(-1);

		if(Input.GetKey(KeyCode.A))
			Strafe(-1);
		
		if(Input.GetKey(KeyCode.D))
			Strafe(1);

		if(Input.GetKeyDown(KeyCode.LeftShift))
			ToggleFast(true);

		if(Input.GetKeyUp(KeyCode.LeftShift))
			ToggleFast(false);

//		this.GetComponent<CharacterController>().Move(moveVector*Time.deltaTime);

	}

	private void ToggleFast(bool _state){

		currentWalkSpeed = ( _state) ? fastWalk: normalWalk;

		currentRotationSpeed = ( _state) ? fastRotation: normalRotation;

		currentStrafeSpeed = ( _state) ? fastStrafe: normalStrafe;
	}

	private void Move(int _direction){
	
//		moveVector += localTransform.forward * _direction * walkSpeed;
		this.GetComponent<CharacterController>().Move(localTransform.forward * _direction * currentWalkSpeed*Time.deltaTime);

//		_linkToINTRO.AdvanceToPlayer(walkSpeed*Time.deltaTime);
	}

	private void Strafe(int _direction){

//		moveVector += localTransform.right * _direction * walkSpeed;
		this.GetComponent<CharacterController>().Move(localTransform.right * _direction * currentWalkSpeed*Time.deltaTime);
	}


	private void Turn(int _direction){

		//Rotate xDegrees 
		localTransform.Rotate(Vector3.up * _direction * currentRotationSpeed * Time.deltaTime);
	}

	public void OnControllerColliderHit(ControllerColliderHit _hit){

		if(_hit.collider.tag == "Interactable"){

			Rigidbody _body = _hit.collider.attachedRigidbody;
			if (_body != null && !_body.isKinematic)
				_body.velocity += this.GetComponent<CharacterController>().velocity*0.1F;

			BaseAction _action = _hit.collider.GetComponent<BaseAction>();
			if(_action != null)
				_action.Action();

		}
	}
}
