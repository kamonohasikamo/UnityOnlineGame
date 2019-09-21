using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[SerializeField] private Vector3 playerMoveVector;
	[SerializeField] private float moveSpeed = 5.0f;

	// オンライン化に必要なコンポーネント
	public PhotonView myPV;
	public PhotonTransformView myPTV;
	private Camera mainCam;

	private Transform player;

	 void Start() {
		player = transform;
		// 自分のキャラなら
		if (myPV.isMine) {
			mainCam = Camera.main;
			mainCam.GetComponent<CameraController>().target = this.gameObject.transform;
		}
	 }
	void Update() {
		if (!myPV.isMine) {
			return;
		}

		playerMoving();
	}

	void playerMoving() {
		playerMoveVector = Vector3.zero;
		if (Input.GetKey(KeyCode.W)) {
			playerMoveVector.z += 1;
		}
		if (Input.GetKey(KeyCode.A)) {
			playerMoveVector.x -= 1;
		}
		if (Input.GetKey(KeyCode.S)) {
			playerMoveVector.z -= 1;
		}
		if (Input.GetKey(KeyCode.D)) {
			playerMoveVector.x += 1;
		}
		// 1second moveSpeed moving
		playerMoveVector = playerMoveVector.normalized * moveSpeed * Time.deltaTime;
		
		// if moving
		if (playerMoveVector.magnitude > 0) {
			transform.position += playerMoveVector;
		}
		Vector3 velocity = playerMoveVector;
		myPTV.SetSynchronizedValues(velocity, 0);
	}
}
