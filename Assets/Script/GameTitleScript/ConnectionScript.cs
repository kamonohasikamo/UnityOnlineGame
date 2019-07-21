using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConnectionScript : Photon.PunBehaviour {
	private string gameVersion = "testGameVersion";

	public void Connect() {
		if(!PhotonNetwork.connected) {
			PhotonNetwork.ConnectUsingSettings(gameVersion);
			Debug.Log("Photonに接続");
		}
	}

	// Photon コールバック
	public override void OnJoinedLobby() {
		Debug.Log("into Lobby");
		// Randomで部屋選び・部屋に入る
		// 部屋がなければOnPhotonRandomJoinFailedが呼ばれる
		PhotonNetwork.JoinRandomRoom();
	}

	public override void OnPhotonRandomJoinFailed(object[] codeAndMsg) {
		Debug.Log("ルームに入れませんでした。");
		PhotonNetwork.CreateRoom("TestRoom");
	}

	public override void OnJoinedRoom() {
		Debug.Log("Room に入りました。");
		PhotonNetwork.LoadLevel("Game");
	}

}
