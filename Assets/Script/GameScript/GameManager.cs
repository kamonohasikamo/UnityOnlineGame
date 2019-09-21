using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {
	public GameObject playerPrefab;

	void Start() {
		// Photonに接続されていなければログイン画面に戻る
		if (!PhotonNetwork.connected) {
			SceneManager.LoadScene("Title");
			return;
		}
		GameObject Player = PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(0f, 0f, 0f), Quaternion.identity, 0);
	
	}
}
